using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint, grandChild;

    private Character character;

	// Use this for initialization
	void Start () {
        character = FindObjectOfType<Character>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        character.transform.position = currentCheckpoint.transform.position;
    }
}
