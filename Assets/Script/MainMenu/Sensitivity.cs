using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sensitivity : MonoBehaviour
{
    public InputField inputField;

    public float standartSensitivity = 10f;

    void Start() 
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
        if(value[(value.Length-1)]> 47 && value[(value.Length-1)]< 58)
        {
            PlayerPrefs.SetFloat("Sensitivity",int.Parse(value));
            standartSensitivity = int.Parse(value);
        }
        else
        {
           value = value.Substring(0, value.Length - 1);
           inputField.text = value;
        }
        Debug.Log(PlayerPrefs.GetFloat("Sensitivity"));

    }
    public void OnEditEnd(string value)
    {
        if(value.Length < 1) 
        {
            PlayerPrefs.SetFloat("Sensitivity",standartSensitivity); 
        }
    }
   
    
   
}
