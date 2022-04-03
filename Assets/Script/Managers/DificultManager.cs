using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultManager : MonoBehaviour
{
    public PlayerHP playerHP;

    private float dificultConstant = 20.0f;

    private float timer = 0.0f;

    public float incrementDificult = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= dificultConstant)
        {
            playerHP.decreasePerSecond = playerHP.decreasePerSecond + incrementDificult ; 
            timer = 0.0f;
        }
        
    }
}
