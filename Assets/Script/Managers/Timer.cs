using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Tooltip("Tiempo onicial en segundos")]
    public float inicialTimer;

    [Tooltip("Tiempo onicial en segundos")]
    [Range(-10.0f, 10.0f)]
    public float scaleTime = 1;

    private Text timer;
    private float timeFramexTimeScale = 0f;
    private float timeInSecons = 0f;
    private float scaleInicialTempo;


    //public float timerScore;
    //public int score = 0;

    public void UpdateTimer(float timeInSecons)
    {
        int minuts = 0;
        int secons = 0;
        int hour = 0;
        string textTimer;

        if (timeInSecons < 0) timeInSecons = 0;

        hour = (int)timeInSecons / 3600;
        minuts = (int)(timeInSecons - (hour * 3600)) / 60;
        secons = (int)timeInSecons % 60;
        

        textTimer = hour.ToString("00") + ":" + minuts.ToString("00") + ":" + secons.ToString(("00"));

        timer.text = textTimer;
    }
    
    void Start()
    {
        scaleInicialTempo = scaleTime;

        timer = GetComponent<Text>();

        timeInSecons = inicialTimer;

        UpdateTimer(timeInSecons);
      
    }
    void Update()
    {
        timeFramexTimeScale = Time.deltaTime * scaleTime;

        timeInSecons += timeFramexTimeScale;

        UpdateTimer(timeInSecons);
    }
}
