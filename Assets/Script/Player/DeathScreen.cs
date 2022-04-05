using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject gm;
    void Update()
    {
    }
    private void OnEnable()
    {
        PlayerHP.OnRequestingPlayerDeath += ActivateDeathScreen;
    
    }
    private void OnDisable()
    {
        PlayerHP.OnRequestingPlayerDeath -= ActivateDeathScreen;
    }

    public void ActivateDeathScreen()
    {
        gm.SetActive(true);
        Time.timeScale = 0.0f;
    }

    }
