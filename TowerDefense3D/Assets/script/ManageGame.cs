using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGame : MonoBehaviour
{
    private bool GameEnded = false;

    public GameObject LoseScreen;
    // Update is called once per frame
    void Update()
    {
        if (GameEnded)
            return;

        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameEnded = true;
        LoseScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
