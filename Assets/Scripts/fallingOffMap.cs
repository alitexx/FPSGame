using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingOffMap : MonoBehaviour
{
    public GameObject LoseMenu;
    public GameObject gameplayGUIS;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PLAYER")
        {
            Time.timeScale = 0f;
            gameplayGUIS.SetActive(false);
            LoseMenu.SetActive(true);
        }
    }
}
