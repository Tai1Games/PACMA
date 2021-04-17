using System.Collections.Generic;
using UnityEngine;
using Utility;
public class Poste : MonoBehaviour
{
    public Transform padreCarteles;
    int nCarteles;
    List<GameObject> carteles = new List<GameObject>();
    private Sentido correct;

    public GameObject cartelDirecciones;
    public GameObject cartelSeguirRecto;

    public float posteRotVal = 8;
    public float cartelRotVal = 15;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Vector3 pos, List<Utility.Sentido> direcciones, int posteTipo,Sentido correcta = Sentido.Izquierda)
    {
        if (posteTipo != 3) //Yeah I know
            //Understandable, have a nice day
        {
            transform.Rotate(new Vector3(1, 0, 0), Random.Range(-posteRotVal, posteRotVal));
            transform.Rotate(new Vector3(0, 0, 1), Random.Range(-posteRotVal, posteRotVal));
        } 

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

            if (direcciones[k] == Sentido.Recto)
            {
                cartelActual = carteles[2 * k + 1];
                carteles[2 * k].SetActive(false);
            }
            else
            {
                cartelActual = carteles[2 * k];
                carteles[2 * k + 1].SetActive(false);
                if (direcciones[k] == Sentido.Derecha)
                    cartelActual.transform.localScale = new Vector3(-cartelActual.transform.localScale.x, cartelActual.transform.localScale.y, cartelActual.transform.localScale.z);
            }

            //TODO Aquí poner las imágenes pero por el momento xd
            //TODO que genere la imagen correcta donde el sentido de correcta

            //Personalizar un poco los carteles
            float scaleVar = Random.Range(1.0f, 1.2f);
            cartelActual.transform.localScale *= scaleVar;

            float rotVar = Random.Range(-cartelRotVal, cartelRotVal);
            if(direcciones[k] != Sentido.Recto) 
                cartelActual.transform.Rotate(new Vector3(0, 1, 0), rotVar);
            else 
                cartelActual.transform.Rotate(new Vector3(1, 0, 0), rotVar);
        }
    }

    public Sentido getCorrectDir()
    {
        return correct;
    }
}
