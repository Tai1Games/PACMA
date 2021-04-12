using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Poste : MonoBehaviour
{
    public GameObject padreCarteles;
    int nCarteles;
    GameObject[] carteles;
    // Start is called before the first frame update
    void Start()
    {
        carteles = padreCarteles.GetComponentsInChildren<GameObject>();
        nCarteles = carteles.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Vector3 pos, List<Utility.Direccion> direcciones)
    {
        transform.position = pos;
        for (int k = 0; k < direcciones.Count; k++)
        {
            //Giramos los carteles
            if (direcciones[k].sentido == Sentido.Derecha) carteles[k].transform.rotation = new Quaternion (carteles[k].transform.rotation.x, 0, 180, 0);

            //Aquí poner las imágenes pero por el momento xd

            //Personalizar un poco los carteles
            float scaleVar = Random.Range(1.0f, 2.0f);
            carteles[k].transform.localScale *= scaleVar;

            float rotVar = Random.Range(-15, 15);

        }
    }
}
