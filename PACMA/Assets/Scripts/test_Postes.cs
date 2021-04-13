using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class test_Postes : MonoBehaviour
{
    public List<GameObject> vecPostes;
    // Start is called before the first frame update
    void Start()
    {
        //POSTE DE TAMAÑO 1

        Poste poste = Instantiate(vecPostes[0]).GetComponent<Poste>();
        List<Direccion> direcciones = new List<Direccion>();

        Direccion dir;
        dir.sentido = Sentido.Recto;
        dir.destino = 0;

        direcciones.Add(dir);

        poste.Init(new Vector3(0, 0, 0), direcciones);

        //POSTE DE TAMAÑO 2
        poste = Instantiate(vecPostes[1]).GetComponent<Poste>();
        direcciones = new List<Direccion>();

        dir.sentido = Sentido.Derecha;
        dir.destino = 0;

        direcciones.Add(dir);

        dir.sentido = Sentido.Izquierda;
        dir.destino = 0;

        direcciones.Add(dir);

        poste.Init(new Vector3(10, 0, 0), direcciones);

        //POSTE DE TAMAÑO 3
        poste = Instantiate(vecPostes[2]).GetComponent<Poste>();
        direcciones = new List<Direccion>();

        dir.sentido = Sentido.Recto;
        dir.destino = 0;

        direcciones.Add(dir);

        dir.sentido = Sentido.Derecha;
        dir.destino = 0;

        direcciones.Add(dir);

        dir.sentido = Sentido.Recto;
        dir.destino = 0;

        direcciones.Add(dir);

        poste.Init(new Vector3(20, 0, 0), direcciones);

        //POSTE DE TAMAÑO 4
        poste = Instantiate(vecPostes[3]).GetComponent<Poste>();
        direcciones = new List<Direccion>();

        dir.sentido = Sentido.Izquierda;
        dir.destino = 0;

        direcciones.Add(dir);

        dir.sentido = Sentido.Recto;
        dir.destino = 0;

        direcciones.Add(dir);

        poste.Init(new Vector3(50, 0, 0), direcciones);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
