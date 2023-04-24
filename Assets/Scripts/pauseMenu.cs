using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject ui;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && globalVariables.canPause == true)
        {
            togglePause();
        }
    }
    public void togglePause()
    {
            ui.SetActive(!ui.activeSelf);
            Cursor.visible = ui.activeSelf;
            if (ui.activeSelf)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.Confined;
                globalVariables.canPause = false;
            }
            else
            {
            globalVariables.canPause = true;
            Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }
    }
}
