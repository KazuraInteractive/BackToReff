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
    public void OnGUI()
    {
        if (guipuse == true)
        {
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 150f, 300f, 100f), "Продолжить"))
            {
                ispuse = false;
                timer = 0;
                panel.SetActive(false);
            }
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2), 300f, 100f), "В Меню"))
            {
                ispuse = false;
                timer = 0;
                SceneManager.LoadScene(0);
            }
        }
    }
}
