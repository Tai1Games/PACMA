using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceDetection : MonoBehaviour
{

    [SerializeField]
    private string[] m_Keywords = new string[] { "izquierda", "derecha" };

    private KeywordRecognizer m_Recognizer;

    // Start is called before the first frame update
    void Start()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        if(m_Recognizer != null && m_Recognizer.IsRunning)
        {
            m_Recognizer.OnPhraseRecognized -= OnPhraseRecognized;
            m_Recognizer.Stop();
        }
    }
}