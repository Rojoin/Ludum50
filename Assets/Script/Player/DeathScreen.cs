using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    
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
        
    }

    }
