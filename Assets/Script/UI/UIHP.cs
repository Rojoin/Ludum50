using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIHP : MonoBehaviour
{

    [SerializeField] PlayerHP playerHP;
    public Slider hpSlider;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = playerHP.currentLifePoints;
    }
}