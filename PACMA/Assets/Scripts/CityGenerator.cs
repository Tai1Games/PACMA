using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class CityGenerator : MonoBehaviour
{
	//Parametros de generacion
	public List<GameObject> straights;
	public List<GameObject> intersections;
	public int tileSize = 5;
	public int maxStraight = 3;
	public int minStraight = 1;

	public ParticleSystem ps;

	//Jugador
	public GameObject player;
	public PlayerCollisionHandler playerColHandler;
	public float playerSpeed = 1;
	private bool moving = false;
	private Sentido playerNextDir = Sentido.Recto;

	private bool tweetDer = false;
	private bool tweetIz = false;

	//Listas para guardar las carreteras que vamos generando
	private List<GameObject> currentCarretera;
	GameObject inters = null, lastTile = null, tileOpt1 = null, tileOpt2 = null, oldInters = null;
	Vector3 facingVec = new Vector3(0, 0, 1);
	Vector3 origin = Vector3.zero;

	GameObject PlaceTile(GameObject tile, Vector3 direccionVec, Vector3 previousTilePos)
	{
		return Instantiate(tile, previousTilePos + tileSize * direccionVec + origin, Quaternion.LookRotation(direccionVec, Vector3.up));
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

	void GeneraTramo(Vector3 direccionVec, Vector3 startPos)
	{
		lastTile = PlaceTile(straights[Random.Range(0, straights.Count)], direccionVec, startPos);
		currentCarretera.Add(lastTile);
		//currentCarretera.Add(PlaceTile(straights[Random.Range(0, straights.Count)], direccionVec, startPos));
		//Coloca una cantidad de rectas aleatorias
		int nTiles = Random.Range(minStraight, maxStraight);
		for (int i = 1; i < nTiles; i++)
		{
			lastTile = PlaceTile(straights[Random.Range(0, straights.Count)], direccionVec, lastTile.transform.position);
			//currentCarretera.Add(PlaceTile(straights[Random.Range(0, straights.Count)], direccionVec, currentCarretera[i-1].transform.position));
			currentCarretera.Add(lastTile);
		}
		//Coloca una interseccion
		inters = PlaceTile(intersections[Random.Range(0, intersections.Count)], direccionVec, lastTile.transform.position);
		//Generar una tile mas a cada lado de la interseccion
		tileOpt1 = PlaceTile(straights[Random.Range(0, straights.Count)], rotaVector(direccionVec, Sentido.Izquierda), inters.transform.position);

		tileOpt2 = PlaceTile(straights[Random.Range(0, straights.Count)], rotaVector(direccionVec, Sentido.Derecha), inters.transform.position);
	}

	void cleanCarretera()
	{
		foreach (GameObject item in currentCarretera)
		{
			Destroy(item);
		}
		currentCarretera.Clear();
	}

	void initMovement(Sentido dir)
	{
		Destroy(oldInters);
		oldInters = inters;
		switch (dir)
		{
			case Sentido.Recto:
				Debug.Log("Te moristes");
				break;
			case Sentido.Izquierda:
				playerColHandler.logicFRotate(-90);
				LeanTween.rotateAroundLocal(player, new Vector3(0, 1, 0), -90, 1f);
				Destroy(tileOpt2);
				//Clean carretera
				cleanCarretera();
				GeneraTramo(playerColHandler.getLogicF(), tileOpt1.transform.position);
				break;
			case Sentido.Derecha:
				playerColHandler.logicFRotate(90);
				LeanTween.rotateAroundLocal(player, new Vector3(0, 1, 0), 90, 1f);

				Destroy(tileOpt1);
				//Clean carretera
				cleanCarretera();
				GeneraTramo(playerColHandler.getLogicF(), tileOpt2.transform.position);
				break;

		}
		playerNextDir = Sentido.Recto;
	}

	void Start()
	{
		currentCarretera = new List<GameObject>();
		facingVec = playerColHandler.getLogicF();
		GeneraTramo(facingVec, new Vector3(0, 0, 0));
	}

	private void FixedUpdate()
	{
		float p = 1.0f;
		if (Input.GetKey(KeyCode.Space))
		{
			p = 5.0f;
			ps.enableEmission = true;
		}
		else ps.enableEmission = true;

		if (Input.GetKeyDown(KeyCode.J)) LeanTween.rotateAroundLocal(player, new Vector3(0, 1, 0), 90, 2f);

		player.transform.position += playerColHandler.getLogicF() * playerSpeed * p;
	}

	//Para ser llamado por el jugador cuando entre a una interseccion
	public void enteringIntersection()
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
		initMovement(playerNextDir);
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
