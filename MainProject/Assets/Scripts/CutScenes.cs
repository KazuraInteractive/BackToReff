using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScenes : MonoBehaviour {

    [SerializeField]
    public Sprite[] scenes = new Sprite[3];
    [SerializeField]
    public AudioClip[] audios = new AudioClip[3];

    int i = 0;

    public void OnPress()
    {
        if (i < scenes.Length)
        {
            GetComponent<Image>().sprite = scenes[i];
            GetComponent<AudioSource>().PlayOneShot(audios[i]);
            i += 1;
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex <= 4)
            {
                FadeInOut.sce = SceneManager.GetActiveScene().buildIndex + 1;
            }
            else
            {
                FadeInOut.sce = 0;
            }
            FadeInOut.sceneEnd = true;
        }
    }
}
