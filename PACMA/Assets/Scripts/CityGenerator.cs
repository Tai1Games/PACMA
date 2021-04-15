using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class CityGenerator : MonoBehaviour
{
    //Parametros de generacion
    public List<GameObject> straights;
    public List<GameObject> intersections;
    public List<GameObject> straightIntersections;
    public int tileSize = 5;
    public int maxStraight = 3;
    public int minStraight = 1;

    //Jugador
    public GameObject player;
    public GameObject carRotationPivot;
    public float playerSpeed = 1;
    private bool moving = true;
    private Sentido playerNextDir = Sentido.Recto;
    public PlayerCollisionHandler playerColHandler;
    public float tiempoAnimGirar = 1f;

    //Listas para guardar las carreteras que vamos generando
    private List<GameObject> currentCarretera;
    GameObject inters = null, oldInters = null, interRecta = null,
        lastTile = null, tileOptIzq = null, tileOptDer = null;
    Vector3 facingVec = new Vector3(0, 0, 1);

    GameObject PlaceTile(GameObject tile, Vector3 direccionVec, Vector3 previousTilePos)
    {
        return Instantiate(tile, previousTilePos + tileSize * direccionVec, Quaternion.LookRotation(direccionVec, Vector3.up));
    }

    Vector3 rotaVector(Vector3 vec, Sentido dir)
    {
        if (dir == Sentido.Derecha)
            return Quaternion.AngleAxis(90, Vector3.up) * vec;
        else if (dir == Sentido.Izquierda)
            return Quaternion.AngleAxis(-90, Vector3.up) * vec;
        else
            return vec;
    }

    void generaTilesSalidaInterseccion(Vector3 direccionVec)
    {
        //Generar una tile mas a cada lado de la interseccion
        Intersection interActual = inters.GetComponent<Intersection>();
        //Salida izquierda
        if (interActual.salidas.Contains(Sentido.Izquierda))
        {
            tileOptIzq = PlaceTile(straights[Random.Range(0, straights.Count)], rotaVector(direccionVec, Sentido.Izquierda), inters.transform.position);
        }
        if (interActual.salidas.Contains(Sentido.Derecha))
        {
            tileOptDer = PlaceTile(straights[Random.Range(0, straights.Count)], rotaVector(direccionVec, Sentido.Derecha), inters.transform.position);
        }
        if (interActual.salidas.Contains(Sentido.Recto))
        {
            //Generar otro tramo
            GeneraTramo(direccionVec, inters.transform.position, true);
        }
    }

    void GeneraTramo(Vector3 direccionVec, Vector3 startPos, bool generatingStraightExtra)
    {
        lastTile = PlaceTile(straights[Random.Range(0, straights.Count)], direccionVec, startPos);
        currentCarretera.Add(lastTile);

        //Coloca una cantidad de rectas aleatorias
        int nTiles = Random.Range(minStraight, maxStraight);
        for (int i = 1; i < nTiles; i++)
        {
            lastTile = PlaceTile(straights[Random.Range(0, straights.Count)], direccionVec, lastTile.transform.position);
            currentCarretera.Add(lastTile);
        }
        //Coloca una interseccion
        if (!generatingStraightExtra)
        {
            //50% de que salga recta con algun variante
            if (Random.Range(0, 100) % 2 == 0)
            {
                Debug.Log("Spawning straight");
                //Crear recta
                inters = PlaceTile(straightIntersections[Random.Range(0, straightIntersections.Count)], direccionVec, lastTile.transform.position);
            }
            else
            {
                //Crear normal
                inters = PlaceTile(intersections[Random.Range(0, intersections.Count)], direccionVec, lastTile.transform.position);

            }
        }
        else
        {
            if (generatingStraightExtra)
                interRecta = PlaceTile(intersections[Random.Range(0, intersections.Count)], direccionVec, lastTile.transform.position);
            else
                inters = PlaceTile(intersections[Random.Range(0, intersections.Count)], direccionVec, lastTile.transform.position);

        }

        if (!generatingStraightExtra)
            generaTilesSalidaInterseccion(direccionVec);
    }

    void cleanCarretera()
    {
        foreach (GameObject item in currentCarretera)
        {
            Destroy(item);
        }
        currentCarretera.Clear();
    }

    void initMovement(Sentido dir, Intersection inter)
    {
        Destroy(oldInters);
        oldInters = inters;
        if (dir == Sentido.Izquierda && inter.salidas.Contains(Sentido.Izquierda))
        {
            playerColHandler.prepareRotation(Sentido.Izquierda);
            playerColHandler.rotatationTiltAnimation(Sentido.Izquierda);

            //El jugador decide girar a la izquierda y puede
            playerColHandler.logicFRotate(-90);
			LeanTween.rotateAroundLocal(carRotationPivot, new Vector3(0, 1, 0), -90, tiempoAnimGirar).setOnComplete(playerColHandler.endRotation);
            playerColHandler.rotatationTiltAnimation(Sentido.Derecha); //Lo se, leave me alone
            Destroy(tileOptDer);
            cleanCarretera();
            currentCarretera.Add(interRecta);
            currentCarretera.Add(tileOptIzq);
            GeneraTramo(playerColHandler.getLogicF(), tileOptIzq.transform.position, false);
        }
        else if (dir == Sentido.Derecha && inter.salidas.Contains(Sentido.Derecha))
        {
            playerColHandler.prepareRotation(Sentido.Derecha);
            playerColHandler.rotatationTiltAnimation(Sentido.Derecha);

            //El jugador decide girar a la derecha y puede
            playerColHandler.logicFRotate(90);
            LeanTween.rotateAroundLocal(carRotationPivot, new Vector3(0, 1, 0), 90, tiempoAnimGirar).setOnComplete(playerColHandler.endRotation);
            playerColHandler.rotatationTiltAnimation(Sentido.Izquierda);
            Destroy(tileOptIzq);
            cleanCarretera();
            currentCarretera.Add(interRecta);
            currentCarretera.Add(tileOptDer);
            GeneraTramo(playerColHandler.getLogicF(), tileOptDer.transform.position, false);
        }
        else if (dir == Sentido.Recto && inter.salidas.Contains(Sentido.Recto))
        {
            //El jugador decide no girar y puede
            Destroy(tileOptDer);
            Destroy(tileOptIzq);
            inters = interRecta;
            generaTilesSalidaInterseccion(player.transform.forward);
        }
        else
        {
            Debug.LogError("Te moristes");
        }

        playerNextDir = Sentido.Recto;
    }

    IEnumerator rotationWaiter()
    {
        moving = false;
        yield return new WaitForSecondsRealtime(tiempoAnimGirar);
        playerColHandler.endRotation();
        moving = true;
    }

    void Start()
    {
        currentCarretera = new List<GameObject>();
        facingVec = playerColHandler.getLogicF();
        GeneraTramo(facingVec, new Vector3(0, 0, 0), false);
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            float p = 1.0f;
		if (Input.GetKey(KeyCode.Space))
		{
			p = 5.0f;
		}

		player.transform.position += player.transform.forward * playerSpeed * p;
        }
    }

    //Para ser llamado por el jugador cuando entre a una interseccion
    public void EnteringIntersection(Intersection inter)
    {
        Debug.Log("enteringIntersection");
        if (Input.GetKey(KeyCode.RightArrow))
		{
			playerNextDir = Sentido.Derecha;
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			playerNextDir = Sentido.Izquierda;
		}
        initMovement(playerNextDir, inter);
    }

    public void playerTurn(string direction)
    {
        if (direction == "Derecha")
        {
            playerNextDir = Sentido.Derecha;
        }
        else if (direction == "Izquierda")
        {
            playerNextDir = Sentido.Izquierda;
        }
    }
}
