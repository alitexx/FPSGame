using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLoseManager : MonoBehaviour
{
    public TextMeshProUGUI defeatedTXT;

    private void Start()
    {
        globalVariables.canPause = false;
        Cursor.lockState = CursorLockMode.Confined;
        if (gameObject.name == "LoseScreen")
        {
            defeatedTXT.text = "Time Survived: " + (60 - Mathf.Round(globalVariables.timer)).ToString() + "\nBears Defeated: " + (globalVariables.bearsKilled).ToString();
        } else if (gameObject.name == "PauseMenu")
        {
            defeatedTXT.text = "Time Remaining: " + (Mathf.Round(globalVariables.timer)).ToString() + "\nBears Defeated: " + (globalVariables.bearsKilled).ToString();
        }
        else
        {
            defeatedTXT.text = "Bears Defeated: " + (globalVariables.bearsKilled).ToString();
        }
        
    }
}
