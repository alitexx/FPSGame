using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingOffMap : MonoBehaviour
{
    public GameObject LoseMenu;
    public GameObject gameplayGUIS;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "PLAYER")
        {
            Time.timeScale = 0f;
            gameplayGUIS.SetActive(false);
            LoseMenu.SetActive(true);
        }
    }
}
