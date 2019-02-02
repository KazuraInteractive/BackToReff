using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour {

    public SaveLoad saveLoad;
    public Button load;

    public void Update()
    {
        saveLoad.LoadPlayerPrefs();
        if (saveLoad.loadLvl < 4)
        {
            load.gameObject.SetActive(false);
        }
        else
        {
            load.gameObject.SetActive(true);
        }
    }

    public void PlayPressed()
    {
        FadeInOut.sce = 1;
        if (FadeInOut.sceneStarting == false)
        {
            FadeInOut.sceneEnd = true;
        }
    }

    public void Continue()
    {
        saveLoad.LoadPlayerPrefs();
        SceneManager.LoadScene(saveLoad.loadLvl);
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
