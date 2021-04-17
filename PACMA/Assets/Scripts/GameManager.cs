using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Text recordText;

    public CarMainMenu car;

    private int record;

    private int currentPoints = 0;

    public int pointsToWin = 3;

    private Text pointsText = null;

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
        recordText.text = record.ToString();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) updateRecord(1);
    }

    public void updateRecord(int p)
    {
        record += p;
        recordText.text = record.ToString();
    }

    public void SendCommand(string command)
    {
        if (command == "Start")
        {
            Debug.Log("Vamo a jugal ... cuando llegue el coche");
            
            car.StartCar();
            
        }else if(command == "Exit"){
            Debug.Log("Saliendo del juego");
            Application.Quit();
        }
    }

    public IEnumerator LoadSceneAsync(string sceneName)
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

    public float GetPoints()
    {
        return currentPoints;
    }

    public float GetPointsForWin()
    {
        return pointsToWin;
    }

    public void AddPoint()
    {
        currentPoints += 1;
        pointsText.text = currentPoints.ToString("000");
    }

    public void RemovePoint()
    {
        currentPoints = (currentPoints > 0) ? currentPoints-1 : 0;
        pointsText.text = currentPoints.ToString("000");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MenuPrincipal")
            car = GameObject.FindWithTag("FordfiestaInicio").GetComponent<CarMainMenu>();
        if(scene.name == "Juego")
            pointsText = GameObject.FindWithTag("TextoPuntuacion").GetComponent<Text>();
    }
}
