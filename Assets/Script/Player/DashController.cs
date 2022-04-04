using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class DashController : MonoBehaviour
{
    public delegate void RequestingDash();
    public static event RequestingDash OnRequestingDash;
    FirstPersonController moveScript;
    public float dashSpeed;
    public float dashTime;
    public Image dashImage;
    public float dashCooldownMax;
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
            OnRequestingDash?.Invoke();
            yield return null;
        }
        float startCooldown = 0f;
        while(dashCooldownMax > startCooldown)
        {
            startCooldown += Time.deltaTime;
            dashImage.fillAmount= startCooldown/dashCooldownMax;
            yield return null;
        }
        dashing = false;
    }
}
