using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public float scrollSpeed = 10;
    public float lateralSeparation = 50;
    public float farPlane = 100;
    public int numOfPools = 4;
    public GameObject[] buildingPref_;
    List<GameObject> activeLeft_;
    List<GameObject> activeRight_;
    List<GameObject> pools_;
    private static readonly Vector3 scrollDir = Vector3.back;
    GameObject PopulatePool()
    {
        GameObject p = new GameObject();
        p.transform.SetParent(transform);
        for (float pos = 0; pos < farPlane;) 
        { 
            GameObject nextBuilding = Instantiate(buildingPref_[Random.Range(0, buildingPref_.Length)],p.transform);
            //Posicion del siguiente edificio
            nextBuilding.transform.Translate(-scrollDir * pos);
            //Ajuste por ancho
            nextBuilding.transform.Translate(-scrollDir * nextBuilding.GetComponent<MeshRenderer>().bounds.size.z / 2);
            pos += nextBuilding.GetComponent<MeshRenderer>().bounds.size.z;

        }
        return p;
    }
    GameObject popRandomFromPool()
    {
        int i = Random.Range(0, pools_.Count-1);
        GameObject g = pools_[i];
        pools_.RemoveAt(i);
        return g;
    }
    void Start()
    {
        activeRight_ = new List<GameObject>();
        activeLeft_ = new List<GameObject>();
        pools_ = new List<GameObject>();
        for (int i = 0; i < numOfPools; i++)
            pools_.Add(PopulatePool());
        for(int i = 0; i < 2; i++)
        {
            activeLeft_.Add(popRandomFromPool());
            activeLeft_[activeLeft_.Count - 1].transform.Translate(Vector3.left * lateralSeparation);
            activeLeft_[activeLeft_.Count - 1].transform.Translate(scrollDir * farPlane * i);

            activeRight_.Add(popRandomFromPool());
            activeRight_[activeRight_.Count - 1].transform.Translate(Vector3.left * -lateralSeparation);
            activeRight_[activeRight_.Count - 1].transform.Translate(scrollDir * farPlane * i);

        }
    }
    //Devuelve una calle a la pool y recibe otra nueva
    GameObject ChangeStreet(List<GameObject> lista,GameObject b,int i)
    {
        b.SetActive(false);
        lista.RemoveAt(i);
        pools_.Add(b);
        //Añadimos una nueva calle
        GameObject newStreet = popRandomFromPool();
        newStreet.SetActive(true);
        return newStreet;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i< activeLeft_.Count;i++)
        {
            GameObject b = activeLeft_[i];
            b.transform.Translate(scrollDir * scrollSpeed * Time.deltaTime);
            if (b.transform.position.z < -farPlane)
            {
                GameObject newStreet = ChangeStreet(activeLeft_, b, i);
                newStreet.transform.SetPositionAndRotation(new Vector3(-lateralSeparation, 0, farPlane),newStreet.transform.rotation);
                activeLeft_.Add(newStreet);
            }
        }
        for (int i = 0; i < activeRight_.Count; i++)
        {
            GameObject b = activeRight_[i];
            b.transform.Translate(scrollDir * scrollSpeed * Time.deltaTime);
            if (b.transform.position.z < -farPlane)
            {
                GameObject newStreet = ChangeStreet(activeRight_, b, i);
                newStreet.transform.SetPositionAndRotation(new Vector3(lateralSeparation, 0, farPlane), newStreet.transform.rotation);
                activeRight_.Add(newStreet);
            }
        }
    }
}
