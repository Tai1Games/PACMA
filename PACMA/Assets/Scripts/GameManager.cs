using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager instance = null;

    private int record;

    public string gameSceneName;
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
        if (PlayerPrefs.HasKey("record")) record = PlayerPrefs.GetInt("record");
        else record = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getRecord()
    {
        return record;
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
        else if (command == "Start")
        {
            Debug.Log("Vamo a jugal");
            StartCoroutine(LoadSceneAsync("t_Postes"));
        }else if(command == "Exit"){
            Debug.Log("Saliendo del juego");
            Application.Quit();
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        Debug.Log("Loading scene: " + sceneName);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("record", record);
    }
}
