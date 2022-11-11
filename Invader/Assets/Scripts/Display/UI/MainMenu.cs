using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play(string sceneName)
    {
        Debug.Log("Play");
        SceneManager.LoadScene(sceneName);
    }

    public void Restart()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
