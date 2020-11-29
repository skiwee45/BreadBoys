using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] playables;
    static private int player;

    private bool isSpawned;

    private string sceneName;

    [SerializeField] private Transform playerSpawnLocation;

    void Start()
    {
        isSpawned = false;
        //WhiteBread();
    }

    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "MainMenu" || sceneName == "Preformance")
        {
            isSpawned = false;
        }

        if (isSpawned == false)
        {
            if (sceneName == "Game")
            {
                if (player == null)
                {
                    player = 0;
                }
                UnityEngine.Debug.Log(playables[player].name);
                Instantiate(playables[player], playerSpawnLocation.position, Quaternion.identity);
                isSpawned = true;
            }
        }
    }

    #region Button Methods

    public void WhiteBread()
    {
        player = 0;
        UnityEngine.Debug.Log(playables[player].name);
    }

    public void WholeWheatBread()
    {
        player = 1;
        UnityEngine.Debug.Log(playables[player].name);
    }

    public void Soggy()
    {
        player = 2;
        UnityEngine.Debug.Log(playables[player].name);
    }

    public void Frozen()
    {
        player = 3;
        UnityEngine.Debug.Log(playables[player].name);
    }

    public void Toasted()
    {
        player = 4;
        UnityEngine.Debug.Log(playables[player].name);
    }

    public void Baguette()
    {
        player = 5;
        UnityEngine.Debug.Log(playables[player].name);
    }

    public void Tortilla()
    {
        player = 6;
        UnityEngine.Debug.Log(playables[player].name);
    }

    public void Ramsay()
    {
        player = 7;
        UnityEngine.Debug.Log(playables[player].name);
    }
    #endregion
}
