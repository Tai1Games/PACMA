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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) UpdateEstres(3);
        if (Input.GetKeyDown(KeyCode.DownArrow)) UpdateEstres(-3);
    }

    public void UpdateEstres(float nivel)
    {
        nivelEstres += nivel;
        nivelEstres = Mathf.Clamp(nivelEstres, 0, 100);
        Debug.Log("Nivel de estres: " + nivelEstres);
        Color color = imagen.color;
        color.a = nivelEstres / 100;
        imagen.color = color;
        Debug.Log("Alfa de la imagen: " + imagen.color.a);
        animador.speed = 1 + (nivelEstres / 10);
        Debug.Log("Velocidad de la animación " + animador.speed);
    }
}
