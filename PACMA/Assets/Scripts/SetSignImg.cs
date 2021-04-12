using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSignImg : MonoBehaviour
{
    private RawImage img;
    [SerializeField]
    private Texture[] imagenes;
    
    void Start()
    {
        img = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
