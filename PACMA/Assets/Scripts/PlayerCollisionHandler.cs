using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public CityGenerator cityManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Intersection inter = other.gameObject.GetComponent<Intersection>();
        if(inter)
            cityManager.EnteringIntersection(inter);
    }
}
