using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

/*      Ejemplo para crear postes. Se que se podria hacer mejor lo de los vectores pero estamos aqui para mermedalear.
 
        //POSTE DE TAMAÑO 1

        Poste poste = Instantiate(vecPostes[0]).GetComponent<Poste>();
        List<Direccion> direcciones = new List<Direccion>();

        Direccion dir;
        dir.sentido = Sentido.Derecha;
        dir.destino = 0;

        direcciones.Add(dir);

        poste.Init(new Vector3(0, 0, 10), direcciones);

        //POSTE DE TAMAÑO 2
        poste = Instantiate(vecPostes[1]).GetComponent<Poste>();
        direcciones = new List<Direccion>();

        dir.sentido = Sentido.Derecha;
        dir.destino = 0;

        direcciones.Add(dir);

        dir.sentido = Sentido.Izquierda;
        dir.destino = 0;

        direcciones.Add(dir);

        poste.Init(new Vector3(0, 0, 20), direcciones);

        //POSTE DE TAMAÑO 3
        poste = Instantiate(vecPostes[2]).GetComponent<Poste>();
        direcciones = new List<Direccion>();

        dir.sentido = Sentido.Derecha;
        dir.destino = 0;

        direcciones.Add(dir);

        dir.sentido = Sentido.Derecha;
        dir.destino = 0;

        direcciones.Add(dir);

        dir.sentido = Sentido.Derecha;
        dir.destino = 0;

        direcciones.Add(dir);

        poste.Init(new Vector3(0, 0, 30), direcciones);
*/


public class Poste : MonoBehaviour
{
    public Transform padreCarteles;
    int nCarteles;
    List<GameObject> carteles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Vector3 pos, List<Utility.Direccion> direcciones)
    {
        foreach (Transform hijo in padreCarteles)
        {
            carteles.Add(hijo.gameObject);
        }
        nCarteles = carteles.Count;

        transform.position = pos;
        for (int k = 0; k < direcciones.Count; k++)
        {
            //Giramos los carteles
            if (direcciones[k].sentido == Sentido.Derecha) carteles[k].transform.localScale = new Vector3(-carteles[k].transform.lossyScale.x, carteles[k].transform.lossyScale.y, carteles[k].transform.lossyScale.z);

            //Aquí poner las imágenes pero por el momento xd

            //Personalizar un poco los carteles
            float scaleVar = Random.Range(1.0f, 1.2f);
            carteles[k].transform.localScale *= scaleVar;

            float rotVar = Random.Range(-20, 20);
            carteles[k].transform.Rotate(new Vector3(0, 1, 0), rotVar);
        }
    }
}
