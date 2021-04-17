using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    public List<Utility.Sentido> salidas;
    private Utility.Sentido correcta;
    void Start()
    {
        correcta = salidas[Random.Range(0, salidas.Count)];
    }
    public Utility.Sentido getCorrect()
    {
        return correcta;
    }
}
