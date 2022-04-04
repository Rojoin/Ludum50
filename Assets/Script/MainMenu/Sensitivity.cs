using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sensitivity : MonoBehaviour
{
    public InputField inputField;

    public float standartSensitivity = 10f;
    public int maxDigits = 3;
    public SensitivityManager sensitivityManager;
    void OnEnable() 
    {
       if(PlayerPrefs.HasKey("Sensitivity"))
       {
           standartSensitivity = PlayerPrefs.GetFloat("Sensitivity");
           inputField.text =  standartSensitivity.ToString();
       }
       else
       {
           PlayerPrefs.SetFloat("Sensitivity",standartSensitivity);
       }
    }
    public void OnValueChanged(string value)
    {
        if(value[(value.Length-1)]> 47 && value[(value.Length-1)]< 58 && value.Length <= 3 || value[(value.Length-1)]==46)
        {
            PlayerPrefs.SetFloat("Sensitivity",float.Parse(value));
	    standartSensitivity = float.Parse(value);
            
        }
        else
        {
           value = value.Substring(0, value.Length - 1);
           inputField.text = value;
        }
        if (sensitivityManager != null)
        sensitivityManager.SetSpeed();
    }
    public void OnEditEnd(string value)
    {
        if(value.Length < 1) 
        {
            PlayerPrefs.SetFloat("Sensitivity",standartSensitivity);

            if (sensitivityManager != null)
                sensitivityManager.SetSpeed();
        }

    }
   
    
   
}