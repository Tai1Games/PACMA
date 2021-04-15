using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Bocadillos { izquierda, derecha, recto, confuso }

public class BocadilloConductor : MonoBehaviour
{
    private Animator animator;
    private Image bocadillo;
    public List<Image> imagenesBocadillo;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        bocadillo = GetComponent<Image>();
        hideBocadillo();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) showBocadillo(Bocadillos.izquierda);
    }

    public void showBocadillo(Bocadillos estado)
    {
        hideBocadillo();
        switch (estado)
        {
            case Bocadillos.izquierda:
                imagenesBocadillo[0].enabled = true;
                break;
            case Bocadillos.derecha:
                imagenesBocadillo[1].enabled = true;
                break;
            case Bocadillos.recto:
                imagenesBocadillo[2].enabled = true;
                break;
            case Bocadillos.confuso:
                imagenesBocadillo[3].enabled = true;
                break;
        }
        bocadillo.enabled = true;
        animator.Play(1);
    }

    public void hideBocadillo()
    {
        bocadillo.enabled = false;
        foreach (Image im in imagenesBocadillo) im.enabled = false;
    }
}
