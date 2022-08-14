using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public int sceneToLoad;

    
    public void Interact()
    {
        Debug.Log(gameObject.name + " interacted");
        SceneManager.LoadScene(sceneToLoad);
    }
}