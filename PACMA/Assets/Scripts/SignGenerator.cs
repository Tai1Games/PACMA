using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class SignGenerator : MonoBehaviour
{
    public List<GameObject> vecPostes;

    /// <summary>
    ///  ID [0 - nº señales) de la imagen del sitio al que vamos.
    ///  Posiblemente acabará estando en el PartidaManager.
    /// </summary>
    public int imgID;
    private CityGenerator cityGenerator;
    Intersection inter = null;

    private void Start()
    {
        cityGenerator = GetComponent<CityGenerator>();
    }

    /// <summary>
    /// </summary>
    /// <returns> una direccion aleatoria de entre las disponibles en inter.salidas </returns>
    Utility.Sentido GetRandomSentidoAvailable()
    {
        Utility.Sentido s;
        do s = Random.Range((int)Utility.Sentido.Derecha, (int)Utility.Sentido.Recto + 1) + Utility.Sentido.Derecha;
            while (!inter.salidas.Contains(s));
        return s;
    }

    void PlacePoste()
    {
        // obtiene las intersecciones del siguiente cruce
        GameObject inters = cityGenerator.GetInters();
        inter = inters.GetComponent<Intersection>();

        // el numero de direcciones del cartel es aleatorio
        int numCarteles = Random.Range(0, vecPostes.Count);

        Poste poste = Instantiate(vecPostes[numCarteles]).GetComponent<Poste>();
        List<Utility.Direccion> dirsList = new List<Utility.Direccion>();
        
        for(int i = 0; i < numCarteles; i++)
        {
            Direccion direccion;
            direccion.sentido = GetRandomSentidoAvailable();
            direccion.destino = 0;
            dirsList.Add(direccion);
        }
        poste.Init(new Vector3(0, 0, 0), dirsList, numCarteles);
    }
}