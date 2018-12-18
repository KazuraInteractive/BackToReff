using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScenes : MonoBehaviour {

    [SerializeField]
    public Sprite[] scenes = new Sprite[3];

    int i = 0;

    public void OnPress()
    {
        if (i < scenes.Length)
        {
            GetComponent<Image>().sprite = scenes[i];
            i += 1;
        }
        else
        {
            FadeInOut.sce = SceneManager.GetActiveScene().buildIndex + 1;
            FadeInOut.sceneEnd = true;
        }
    }
}
