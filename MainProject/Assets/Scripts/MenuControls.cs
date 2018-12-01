using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuControls : MonoBehaviour {

    public void PlayPressed()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayPressed2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
