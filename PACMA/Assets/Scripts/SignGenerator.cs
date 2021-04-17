using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class SignGenerator : MonoBehaviour
{
    public List<GameObject> vecPostes;
    public float extraDistance = 50f;
    private PlayerCollisionHandler playerCollision; 

    /// <summary>
    ///  ID [0 - n� se�ales) de la imagen del sitio al que vamos.
    ///  Posiblemente acabar� estando en el PartidaManager.
    /// </summary>
    public int imgID;

    /// <summary>
    /// COMENTARIOS
    /// </summary>
    void Start()
    {
        playerCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisionHandler>();
        if (!playerCollision)
            Debug.Log("No pille la colision xd");
    }

    /// <summary>
    /// </summary>
    /// <returns> una direccion aleatoria de entre las disponibles en inter.salidas </returns>
    Utility.Sentido GetRandomSentidoAvailable(Intersection inter)
    {
        Utility.Sentido s;
        do {
            s = Random.Range((int)Utility.Sentido.Derecha, (int)Utility.Sentido.Recto + 1) + Utility.Sentido.Derecha;
        } while (!inter.salidas.Contains(s));
        return s;
    }

    /// <summary>
    /// Coloca un poste con numero de carteles aleatorio
    /// </summary>
    /// <param name="inter"> Las intersecciones del siguiente cruce </param>
    public void PlacePoste(GameObject intersectionGO)
    {
        //Estupido orden de inicializacion
        if(playerCollision==null)
            playerCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisionHandler>();

        Intersection inter = intersectionGO.GetComponent<Intersection>();
        // el numero de direcciones del cartel es aleatorio entre las direcciones posibles y el maximo de carteles
        int numCarteles = Random.Range(vecPostes.Count, 3) + 1;

        Poste poste = Instantiate(vecPostes[numCarteles - 1]).GetComponent<Poste>();
        List<Utility.Direccion> dirsList = new List<Utility.Direccion>();
        
        for(int i = 0; i < numCarteles; i++)
        {
            Direccion direccion;
            direccion.sentido = GetRandomSentidoAvailable(inter);
            direccion.destino = 0;
            dirsList.Add(direccion);
        }

        Vector3 pos = intersectionGO.GetComponent<PosCartel>().GetPos() - playerCollision.getLogicF() * extraDistance;
        poste.Init(pos, dirsList, numCarteles - 1);
        poste.transform.Rotate(new Vector3(0.0f, intersectionGO.transform.rotation.eulerAngles.y, 0.0f));
        poste.transform.SetParent(intersectionGO.transform);
    }
}