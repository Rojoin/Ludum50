using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
public class DashController : MonoBehaviour
{
    FirstPersonController moveScript;
    public float dashSpeed;
    public float dashTime;
    public InputAction dash;
    bool dashing;
    void Start()
    {
        moveScript = GetComponent<FirstPersonController>();
        dashing = false;
    }
    
    void OnDash()
    {
        if(!dashing) StartCoroutine(Dash());
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        dashing = true;
        while (Time.time < startTime + dashTime)
        {
            
            moveScript.controller.Move(transform.right * moveScript.inputDir.move.x +
                transform.forward * moveScript.inputDir.move.y * dashSpeed * Time.deltaTime);
            yield return null;
        }
        
        dashing = false;
    }
}
