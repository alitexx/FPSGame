using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    public void endGame()
    {
        Application.Quit();
    }
    public void loadLevel(string sceneName)
    {
        Debug.Log("Changing Scenes!");
        Time.timeScale = 1f;
        if (sceneName == "Game")
        {
            Cursor.lockState = CursorLockMode.Locked;
        } else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        SceneManager.LoadScene(sceneName);
    }
}
