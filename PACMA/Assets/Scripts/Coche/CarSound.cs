using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSound : MonoBehaviour
{
    public AudioSource sound;
    [Range(0.0f,1.0f)]
    public float maxVolume;
    public float pitchVariance;
    [Range(0.0f,1.0f)]
    public float startingSpeed;

    [Range(0.0f,1.5f)]
    public float minPitch;
    [Range(1.5f,3.0f)]
    public float maxPitch;

    public float targetPitch;
    
    private bool _starting;
    

    private void Start()
    {
        StartEngine();
    }

    private void Update()
    {
        if (_starting)
        {
            sound.volume = LeanSmooth.linear(sound.volume, maxVolume, startingSpeed);
            if (sound.volume >= maxVolume) _starting = false;
        }
        
        //variamos de manera aleatoria el pitch para que no se siempre constante
        sound.pitch += Random.Range(-pitchVariance, pitchVariance);

        sound.pitch = LeanSmooth.linear(sound.pitch, targetPitch, startingSpeed/10);
        if(sound.pitch == targetPitch) targetPitch = Random.Range(minPitch, maxPitch);
    }

    public void StartEngine()
    {
        _starting = true;
        sound.Play();
        sound.volume = 0;
        sound.pitch = 1f;
        targetPitch = Random.Range(minPitch, maxPitch);
    }
}
