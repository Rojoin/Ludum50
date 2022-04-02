using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIHP : MonoBehaviour
{
    public Slider hpSlider;
    public float decreasePerSecond;
    // Start is called before the first frame update
    void Start()
    {
       hpSlider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value-= Time.deltaTime * decreasePerSecond;
    }
}
