using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIHP : MonoBehaviour
{

    [SerializeField] PlayerHP playerHP;
    public Image life;
    
   
  

    // Update is called once per frame
    void Update()
    {
        life.fillAmount =  playerHP.currentLifePoints/100;
        Debug.Log(playerHP.currentLifePoints/100);
       
    }
}