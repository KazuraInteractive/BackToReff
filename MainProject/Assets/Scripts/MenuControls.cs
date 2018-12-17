using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour {

    public void PlayPressed()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void PlayPressed2()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
