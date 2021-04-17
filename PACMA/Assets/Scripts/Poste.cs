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

            //Personalizar un poco los carteles
            float scaleVar = Random.Range(1.0f, 1.2f);
            cartelActual.transform.localScale *= scaleVar;

            float rotVar = Random.Range(-cartelRotVal, cartelRotVal);
            if(direcciones[k] != Sentido.Recto) 
                cartelActual.transform.Rotate(new Vector3(0, 1, 0), rotVar);
            else 
                cartelActual.transform.Rotate(new Vector3(1, 0, 0), rotVar);
        }

        // comienzo de la carbonara para que los carteles tengan imagen y eso 🍝

        // escoger las imagenes que iran en los carteles
        List<int> idsImgs = new List<int>();
        for (int i = 0; i < posteTipo; i++)
        {
            int newId;
            do
            {
                newId = Random.Range(0, 30);    // no deberia ser 30 sino SetSignImg.imgs.Count() - 1
            } while (idsImgs.Contains(newId));
            idsImgs.Add(newId);
        }

        // colocar las imagenes en los carteles
        for (int i = 0; i < carteles.Count; i++)
        {
            SetSignImg img = carteles[i].GetComponent<SetSignImg>();
            img.SetImg(idsImgs[i], SetSignImg.GetRandomColor());
        }

        // reescribir uno de los carteles con el destino correcto
        int l = 0;
        while (l < direcciones.Count && direcciones[l] != correcta) l++;
        // poner el cartel con la imagen y el color del destino
        carteles[l].GetComponent<SetSignImg>().SetImg(GameManager.instance.GetHospitalDestino(), GameManager.instance.GetColorHospitalDestino());

        // final de la carbonara 🍝
    }

    public Sentido getCorrectDir()
    {
        return correct;
    }
}
