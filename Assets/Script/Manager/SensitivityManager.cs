using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;


public class SensitivityManager : MonoBehaviour
{
    public FirstPersonController playerController;
    
    void Start()
    {
       playerController.RotationSpeed = PlayerPrefs.GetFloat("Sensitivity");

    }
}
