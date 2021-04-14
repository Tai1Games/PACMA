using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public CityGenerator cityManager;

    private Vector3 logicForward;

    // Start is called before the first frame update
    void Start()
    {
        logicForward = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Intersection>())
            cityManager.enteringIntersection();
    }

    public Vector3 getLogicF() {
        return logicForward;
    }

    public void setLogicF(Vector3 t) {
        logicForward = t;
    }

    public void logicFRotate(float angle ) {
        logicForward = Quaternion.AngleAxis(angle, transform.up) * logicForward;
    }
}
