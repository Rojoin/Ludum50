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
    private void Start() {
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gamePlayUI.SetActive(false);
        Time.timeScale = 0.0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void menuButton()
    {
        SceneManager.LoadScene(0);
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

