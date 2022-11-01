using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
