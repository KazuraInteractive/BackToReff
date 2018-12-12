using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScenes : MonoBehaviour {

    [SerializeField]
    public Sprite[] scenes = new Sprite[3];
    [SerializeField]
    int sce;

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
            SceneManager.LoadScene(sce);
        }
    }
}
