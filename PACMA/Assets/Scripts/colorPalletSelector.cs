using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorPalletSelector : MonoBehaviour
{
    public List<Sprite> nombresEmojificados;

    private MaterialManger matManager;
    private int currentPallet = 0;
    private int nPallets;
    public Image imagenNombres;

    // Start is called before the first frame update
    void Start()
    {
        matManager = FindObjectOfType<MaterialManger>(); //Haha chupate esa Eva
        nPallets = nombresEmojificados.Count - 1;
        currentPallet = Random.Range(0, nPallets);

        matManager.setCurrentPallet(currentPallet);
        imagenNombres.sprite = nombresEmojificados[currentPallet];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changePallet(int dir) //Pa alante o pa atrá
    {
        currentPallet += dir;
        if (currentPallet < 0) currentPallet = nPallets;
        else if (currentPallet > nPallets) currentPallet = 0;
        Debug.Log(currentPallet);
        matManager.setCurrentPallet(currentPallet);
        imagenNombres.sprite = nombresEmojificados[currentPallet];
    }
}
