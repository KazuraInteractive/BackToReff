using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause : MonoBehaviour {

    public float timer;
    public bool ispuse = false;
    public bool guipuse;
    public GameObject panel;

    public void Paus()
    {
        ispuse = !ispuse;
    }

    void Update()
    {
        Time.timeScale = timer;

        if (ispuse == true)
        {
            timer = 0;
            guipuse = true;

        }
        else if (ispuse == false)
        {
            timer = 1f;
            guipuse = false;

        }
    }
    public void Continue()
    {
        if (guipuse == true)
        {
            ispuse = false;
            timer = 0;
            panel.SetActive(false);
        }
    }
    public void Exit()
    {
        if (guipuse == true)
        {
            ispuse = false;
            timer = 0;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}

