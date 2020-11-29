using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool beatToaster = false;
    public bool beatDishwasher = false;
    public bool beatFridge = false;
    public bool beatTaco = false;
    public bool beatPasta = false;
    public bool beatRamsay = false;

    public PlayerData(UnlockableBreads data)
    {
        beatToaster = data.ToastedBread;
        beatDishwasher = data.SoggyBread;
        beatFridge = data.FrozenBread;
        beatTaco = data.Tortilla;
        beatPasta = data.Baguette;
        beatRamsay = data.RamsayBread;
    }
}