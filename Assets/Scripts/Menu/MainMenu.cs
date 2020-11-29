using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    AudioSource selectSfx;

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenChannel()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCWGdl66Zrzzdzg4pcnhJZ7Q");
    }

    public void Quit()
    {
        //Debug.Log("QUIT");
        Application.Quit();
    }
}
