using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BreadSelect : MonoBehaviour
{
    [SerializeField] private Text breadName;

    private string sceneName;

    void Start()
    {
        WhiteBread();
    }

    #region Text&Select
    public void WhiteBread()
    {
        breadName.text = "White Bread";
    }

    public void WholeWheatBread()
    {
        breadName.text = "Whole Wheat Bread";
    }

    public void Soggy()
    {
        breadName.text = "Soggy Bread";
    }

    public void Frozen()
    {
        breadName.text = "Frozen Bread";
    }

    public void Toasted()
    {
        breadName.text = "Toast";
    }

    public void Baguette()
    {
        breadName.text = "Baguette";
    }

    public void Tortilla()
    {
        breadName.text = "Tortilla";
    }

    public void Ramsay()
    {
        breadName.text = "Ramsay Bread";
    }
    #endregion
}