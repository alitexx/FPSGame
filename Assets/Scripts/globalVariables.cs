using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVariables : MonoBehaviour
{
    public static float timer = 60;
    public static int bearsKilled = 0;
    public static bool canPause = true;

    private void Start()
    {
        bearsKilled = 0;
        canPause = true;
        timer = 60;
    }
}
