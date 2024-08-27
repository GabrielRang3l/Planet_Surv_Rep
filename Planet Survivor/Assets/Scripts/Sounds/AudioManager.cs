using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource AudioSource;

    [Header("Volume")]
    public float volume = 1.0f;
    [SerializeField] bool isLoop = true;
    [SerializeField] bool isMuted = false;
    [SerializeField] bool isAwake = true;



    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        UpdateAudio();
    }

    public void UpdateAudio()
    {
        AudioSource.volume = volume;
        AudioSource.loop = isLoop;
        AudioSource.mute = isMuted;
        AudioSource.playOnAwake = isAwake;
    }

}
