using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public float health = 50;

    public GameObject LoseMenu;
    public GameObject gameplayGUIS;
    public TextMeshProUGUI healthTXT;
    private bool playerCanTakeDMG = true;
    public AudioSource getHit;
    public IEnumerator damagePlayer()
    {
        if (playerCanTakeDMG == true)
        {
            playerCanTakeDMG = false;
            getHit.Play();
            health -= 10;
            healthTXT.text = health.ToString();
            if (health <= 0)
            {
                globalVariables.canPause = false;
                Time.timeScale = 0f;
                gameplayGUIS.SetActive(false);
                LoseMenu.SetActive(true);
            }
            yield return new WaitForSeconds(1.5f);
            playerCanTakeDMG = true;
        }
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if (hit.gameObject.name ==  "Bear")
        //{
        //    StartCoroutine(damagePlayer());
        //} 
        if (hit.gameObject.name == "deathZone")
        {
            globalVariables.canPause = false;
            Time.timeScale = 0f;
            gameplayGUIS.SetActive(false);
            LoseMenu.SetActive(true);
        }
    }
}
