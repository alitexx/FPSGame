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

    public void Hit(float damage)
    {
        
    }

    IEnumerator damagePlayer()
    {
        if (playerCanTakeDMG == true)
        {
            playerCanTakeDMG = false;
            health -= 10;
            healthTXT.text = health.ToString();
            if (health <= 0)
            {
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
        if (hit.gameObject.name ==  "Bear")
        {
            StartCoroutine(damagePlayer());
        } else if (hit.gameObject.name == "deathZone")
        {
            Time.timeScale = 0f;
            gameplayGUIS.SetActive(false);
            LoseMenu.SetActive(true);
        }
    }
}
