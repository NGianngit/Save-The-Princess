using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public int sceneToLoad;
    public int time;

    private bool isLoaded;

    private void Start()
    {
        isLoaded = true;
    }
    


    private void Update()
    {
        time++;
        Debug.Log("time");
        if (isLoaded)
        {
            return;
        }
        if (time > 1000)
        {
            SceneManager.LoadScene(0)   ;
        }
    }
    
}
