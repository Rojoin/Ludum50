using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dead : MonoBehaviour
{
    public GameObject menuLayer;
    public PlayerHP player;
    bool de = false;  
    private void Awake() {
        Time.timeScale = 1f;
        de = false;
    }
    private void Update() {
        if(player.currentLifePoints <= 0f && !de)
        {
            YouAreDead();
            de = true;
        }
    }
    public void YouAreDead()
    {
        Time.timeScale = 0f;
        StartCoroutine(Deading());
    }
    IEnumerator Deading()
    {
        menuLayer.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(0);
    }
     
}
