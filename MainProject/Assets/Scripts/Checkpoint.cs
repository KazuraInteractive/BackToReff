using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public LevelManager levelManager;
    public GameObject grandChild;


    void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Character")
        {
            levelManager.currentCheckpoint = gameObject;
        }
    }
}
