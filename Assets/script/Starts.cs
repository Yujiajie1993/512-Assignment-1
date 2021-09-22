using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starts : MonoBehaviour
{
public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void set()
    {
        SceneManager.LoadScene("Setting");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
