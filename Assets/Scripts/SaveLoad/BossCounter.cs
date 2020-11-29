using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossCounter : MonoBehaviour
{
    private int bossesDefeated = 0;

    private string sceneName;

    private GameObject bK;
    private BossesKilledText bKT;

    private GameManager gm;

    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Preformance")
        {
            bK = GameObject.FindGameObjectWithTag("bKT");
            bKT = bK.GetComponent<BossesKilledText>();
            bKT.RenderText(bossesDefeated);
        }
        else if (sceneName == "MainMenu")
        {
            bossesDefeated = 0;
        }
        else if (sceneName == "Game")
        {
            gm = FindObjectOfType<GameManager>();
            bossesDefeated = gm.GetCurrentLevel() - 1;
        }
    }
}
