using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrasition : MonoBehaviour
{
    private static MusicTrasition instance;
    AudioSource myAudio;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.PlayDelayed(10.0f);

    }
    void awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
