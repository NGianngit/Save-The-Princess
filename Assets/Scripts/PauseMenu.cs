using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Slider volume;
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        volume.value = AudioListener.volume;
    }

    // Update is called once per frame
    void Update()
    {
        ///escape key pauses and unpauses the game 
        if (GameIsPaused)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    /// <summary>
    /// unpause the game time and close the pause menu and lock the cursor of the player
    /// </summary>
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    /// <summary>
    /// pause the game time and open the pause menu and unlock the cursor of the player
    /// </summary>
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    /// <summary>
    /// change the volume of the in game sound
    /// </summary>
    public void ChangeVolume()
    {

        AudioListener.volume = volume.value;

    }
    /// <summary>
    /// quit the game
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
