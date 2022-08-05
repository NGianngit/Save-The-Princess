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
    private Input input;
    // Start is called before the first frame update
    void Start()
    {
        volume.value = AudioListener.volume;
        //pause the game on escape key press//
        input.UI.Pause.started += ctx => PauseGame();

    }

   
    void PauseGame()
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
    private void Awake()
    {
        input = new Input();
    }
    private void OnEnable()
    {
        input.Enable();

    }
    private void OnDisable()
    {
        input.Disable();

    }
}
