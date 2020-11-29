using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockableBreads : MonoBehaviour
{
    public bool SoggyBread;
    public bool ToastedBread;
    public bool FrozenBread;
    public bool Tortilla;
    public bool Baguette;
    public bool RamsayBread;

    private GameObject soggyUI;
    private GameObject frozenUI;
    private GameObject toastedUI;
    private GameObject baguetteUI;
    private GameObject tortillaUI;
    private GameObject ramsayUI;

    private Button soggy;
    private Button frozen;
    private Button toasted;
    private Button baguette;
    private Button tortilla;
    private Button ramsay;

    private string sceneName;

    void Start()
    {
        LoadPlayer();
    }

    public void SavePlayer()
    {
        SaveSystem.SaveBreads(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        SoggyBread = data.beatDishwasher;
        ToastedBread = data.beatToaster;
        FrozenBread = data.beatFridge;
        Tortilla = data.beatTaco;
        Baguette = data.beatPasta;
        RamsayBread = data.beatRamsay;
    }

    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "MainMenu" || sceneName == "Preformance")
        {
            LoadPlayer();

            soggyUI = GameObject.FindWithTag("Soggy");
            frozenUI = GameObject.FindWithTag("Frozen");
            toastedUI = GameObject.FindWithTag("Toasted");
            baguetteUI = GameObject.FindWithTag("Baguette");
            tortillaUI = GameObject.FindWithTag("Tortilla");
            ramsayUI = GameObject.FindWithTag("Ramsay");

            soggy = soggyUI.GetComponent<Button>();
            frozen = frozenUI.GetComponent<Button>();
            toasted = toastedUI.GetComponent<Button>();
            baguette = baguetteUI.GetComponent<Button>();
            tortilla = tortillaUI.GetComponent<Button>();
            ramsay = ramsayUI.GetComponent<Button>();

            //UnityEngine.Debug.Log("Menu or Performance");
            soggy.interactable = SoggyBread;
            frozen.interactable = FrozenBread;
            toasted.interactable = ToastedBread;
            baguette.interactable = Baguette;
            tortilla.interactable = Tortilla;
            ramsay.interactable = RamsayBread;

            SavePlayer();
            LoadPlayer();
        }
        else if (sceneName == "Game")
        {
            SavePlayer();
            LoadPlayer();
            //UnityEngine.Debug.Log("Game Scene");
        }
    }

    public void SomethingUnlocked(string bossName)
    {
        UnityEngine.Debug.Log(bossName);

        if (bossName == "Fridge")
        {
            FrozenBread = true;
        }
        else if (bossName == "Dishwasher")
        {
            SoggyBread = true;
        }
        else if (bossName == "Ramsay")
        {
            RamsayBread = true;
        }
        else if (bossName == "Taco")
        {
            Tortilla = true;
        }
        else if (bossName == "Toaster")
        {
            ToastedBread = true;
        }
        else if (bossName == "Pasta")
        {
            Baguette = true;
        }
        SavePlayer();
        LoadPlayer();
    }

    public void ResetPlayer()
    {
        UnityEngine.Debug.Log("Reseting!");
        SoggyBread = false;
        ToastedBread = false;
        FrozenBread = false;
        Tortilla = false;
        Baguette = false;
        RamsayBread = false;
        SavePlayer();
        LoadPlayer();
    }
}