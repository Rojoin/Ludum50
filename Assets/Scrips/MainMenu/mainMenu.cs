using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    
    public void playButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public GameObject[] sarasa;
    public void quitButton()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
