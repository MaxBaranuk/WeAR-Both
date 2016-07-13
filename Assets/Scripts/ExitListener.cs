﻿using UnityEngine;
using System.Collections;

public class ExitListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}
