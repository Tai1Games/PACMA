using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class CityGenerator : MonoBehaviour
{
    public List<GameObject> straights;
    public List<GameObject> intersections;
    public float tileSize = 5;
    public float maxStraight = 3;
    public float minStraight = 1;
    Cardinal facing = Cardinal.North;
    Vector3 facingVec = new Vector3(0, 0, 1);
    Vector3 lastSpawnedPos;
    GameObject lastIntersection = null;
    Intersection availableDirs;
    Vector3 origin = Vector3.zero;

    GameObject PlaceTile(GameObject tile)
    {
        GameObject g =  Instantiate(tile, lastSpawnedPos+ tileSize*facingVec + origin, Quaternion.LookRotation(facingVec,Vector3.up));
        lastSpawnedPos = g.transform.position;
        return g;
    }
    void TurnFacingDir(Sentido dir)
    {
        if (dir == Sentido.Derecha)
            facingVec = Quaternion.AngleAxis(90, Vector3.up) * facingVec;
        else if(dir == Sentido.Izquierda)
            facingVec = Quaternion.AngleAxis(-90, Vector3.up) * facingVec;


    }
    void GeneraTramo()
    {
        //Coloca una cantidad de rectas aleatorias
        for (int i = 0; i < Random.Range(minStraight, maxStraight); i++)
        {
            
            PlaceTile(straights[Random.Range(0, straights.Count)]);
        }
        //Coloca una interseccion
        lastIntersection = PlaceTile(intersections[Random.Range(0, intersections.Count)]);
        availableDirs = lastIntersection.GetComponent<Intersection>();
    }
    void Start()
    {
       
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GeneraTramo();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TurnFacingDir(Sentido.Izquierda);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            TurnFacingDir(Sentido.Derecha);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            availableDirs = new Intersection();
            availableDirs.salidas = new List<Sentido>();
            availableDirs.salidas.Add(Sentido.Derecha);
            for(int i = 0; i < 5; i++)
            {
                GeneraTramo();
                TurnFacingDir(availableDirs.salidas[Random.Range(0, availableDirs.salidas.Count)]);
            }
        }

    }
}
