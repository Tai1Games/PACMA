using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class IngameVoiceDetection : VoiceDetection
{
    public CityGenerator cityManager;

    protected override void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        cityManager.playerTurn(command);
    }
}
