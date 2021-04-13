using System.Collections.Generic;
using UnityEngine;
using Utility;
public class Poste : MonoBehaviour
{
    public Transform padreCarteles;
    int nCarteles;
    List<GameObject> carteles = new List<GameObject>();

    public GameObject cartelDirecciones;
    public GameObject cartelSeguirRecto;

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
        nCarteles = carteles.Count / 2;

        transform.position = pos;
        for (int k = 0; k < direcciones.Count; k++)
        {
            //Giramos los carteles
            GameObject cartelActual;

            if (direcciones[k].sentido == Sentido.Recto)
            {
                cartelActual = carteles[2 * k + 1];
                carteles[2 * k].SetActive(false);
            }
            else
            {
                cartelActual = carteles[2 * k];
                carteles[2 * k + 1].SetActive(false);
                if (direcciones[k].sentido == Sentido.Derecha) cartelActual.transform.localScale = new Vector3(-cartelActual.transform.lossyScale.x, cartelActual.transform.lossyScale.y, cartelActual.transform.lossyScale.z);
            }

            //Aquí poner las imágenes pero por el momento xd

            //Personalizar un poco los carteles
            float scaleVar = Random.Range(1.0f, 1.2f);
            cartelActual.transform.localScale *= scaleVar;

            float rotVar = Random.Range(-20, 20);
            cartelActual.transform.Rotate(new Vector3(0, 1, 0), rotVar);
        }
    }
}
