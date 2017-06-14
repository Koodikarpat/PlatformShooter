using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour {
	private bool cursorlocked = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if (cursorlocked == true) {
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				cursorlocked = false;
			}
			else 
				Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			cursorlocked = true;
		}
	}
}
