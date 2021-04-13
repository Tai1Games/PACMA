using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SetSignImg : MonoBehaviour
{
    [System.Serializable]
    public struct Sign
    {
        public float weight;
        public Texture image;
    }

    [SerializeField]
    public Sign[] signs;
    private RawImage img;

    enum DirHospital { Left, Right, Front };
    
    void Start()
    {
        img = GetComponent<RawImage>();
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}