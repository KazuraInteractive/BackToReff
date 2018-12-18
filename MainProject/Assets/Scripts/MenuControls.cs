using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour {

    public void PlayPressed()
    {
        FadeInOut.sce = 1;
        if (FadeInOut.sceneStarting == false)
        {
            FadeInOut.sceneEnd = true;
        }
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
