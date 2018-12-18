﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

    [SerializeField]
    int sce;

    private void OnTriggerEnter2D(Collider2D collider)
    {
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
