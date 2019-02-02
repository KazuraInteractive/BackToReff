using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

    public SaveLoad saveLoad;

    [SerializeField]
    int sce;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        saveLoad.saveLvl = SceneManager.GetActiveScene().buildIndex + 2;
        saveLoad.SavePlayerPrefs();

        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            FadeInOut.sce = SceneManager.GetActiveScene().buildIndex+1;
            if (FadeInOut.sceneStarting == false)
            {
                FadeInOut.sceneEnd = true;
            }
        }
    }
}
