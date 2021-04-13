using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class estres : MonoBehaviour
{
    float nivelEstres = 0;
    public RawImage imagen;
    public Animator animador;
    public float stressIncrement;
    public ShaderEstresScript shaderEstressScript;

    private void Update()
    {
        UpdateEstres(stressIncrement*Time.deltaTime);
    }

    public void UpdateEstres(float nivel)
    {
        nivelEstres += nivel;
        nivelEstres = Mathf.Clamp(nivelEstres, 0, 100);
        //Debug.Log("Nivel de estres: " + nivelEstres);
        Color color = imagen.color;
        color.a = Mathf.Pow(nivelEstres / 100, 2);
        imagen.color = color;
        //Debug.Log("Alfa de la imagen: " + imagen.color.a);
        animador.speed = 1 + (nivelEstres / 10);
        shaderEstressScript.updateIntensityVignete(nivelEstres / 100);
        //Debug.Log("Velocidad de la animación " + animador.speed);
    }
}
