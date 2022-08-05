using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Slider volume;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void ChangeVolume()
    {

        AudioListener.volume = volume.value;

    }
    public void Exit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
