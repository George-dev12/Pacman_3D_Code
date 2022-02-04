using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool playerDied = false, won = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDied) 
        {
            Time.timeScale = 0;
        }
        if (won) 
        {
            //canvas z wygrana, menu -> w przyszlych wersjach gry
            //===================================================
            //aktualnie -> przerywa rozgrywke
            Time.timeScale = 0;
        }
    }
}
