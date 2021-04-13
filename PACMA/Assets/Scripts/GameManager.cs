using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendCommand(string command)
    {
        if (command == "Derecha")
        {
            Debug.Log("Girando a derecha");
        }else if(command == "Izquierda")
        {
            Debug.Log("Girando a izquierda");
        }
        else if (command == "Play" || command == "Jugar" || command == "Empezar" || command == "Entrar")
        {
            Debug.Log("Vamo a jugal");
        }else if(command == "Exit" || command == "Salir"){
            Debug.Log("Saliendo del juego");
        }
    }
}
