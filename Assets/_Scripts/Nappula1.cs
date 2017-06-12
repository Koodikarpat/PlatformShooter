using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nappula1 : MonoBehaviour {
	public void StartGame()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		transform.parent.gameObject.active = false;
	}
		
	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
