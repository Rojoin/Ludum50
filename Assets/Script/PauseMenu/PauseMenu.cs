using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class PauseMenu : MonoBehaviour
{
    public GameObject gamePlayUI;
    public AudioMixer audioMixer;
    public static bool gameIsPaused;
    public GameObject pauseMenuUI;
    private void OnEnable()
    {
        inputSystem.OnRequestingPause += Escape; 
    }
    private void OnDisable()
    {
        inputSystem.OnRequestingPause -= Escape;
    }
    void Escape()
    {
       if (gameIsPaused)
       {
           Resume();
       }
       else
       {
           Pause();
       }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gamePlayUI.SetActive(false);
        Time.timeScale = 0.0f;
        gameIsPaused = true;
    }
    public void menuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void quitButton()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        Debug.Log(volume);
    }
}

