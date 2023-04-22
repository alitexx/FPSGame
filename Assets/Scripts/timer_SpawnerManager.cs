using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer_SpawnerManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject miscGUIs;
    public TextMeshProUGUI timerText;
    public GameObject spawnLocations;
    public List<Transform> bearSpawns = new List<Transform>();
    public GameObject bear;
    private bool spawnAvailable = true;
    // Start is called before the first frame update
    void Start()
    {
        globalVariables.timer = 60;
    }

    // Update is called once per frame
    void Update()
    {
        globalVariables.timer -= Time.deltaTime;
        timerText.text = (Mathf.Round(globalVariables.timer)).ToString();
        if (globalVariables.timer < 0)
        {
            Time.timeScale = 0f;
            miscGUIs.SetActive(false);
            if (globalVariables.bearsKilled > 0)
            {
                winScreen.SetActive(true);
            }
            else
            {
                loseScreen.SetActive(true);
            }
            Destroy(gameObject);
        }
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        if (globalVariables.timer > 0 && spawnAvailable != false)
        {
            spawnAvailable = false;
            GameObject bearInGame = Instantiate(bear, bearSpawns[Random.Range(0,8)].position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
            spawnAvailable = true;
        } else
        {
            yield return new WaitForSeconds(200);
        }
    }
}
