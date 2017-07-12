using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scope : MonoBehaviour 
{

	public Animator Animator;
	public GameObject scopeOverlay;
	public bool isScoped = false;
	public GameObject sniper;
	public Camera mycamera;
	private int fov = 60;

	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetButtonDown ("Fire2")) 
		{
			isScoped = !isScoped;
			Animator.SetBool ("Scoped", isScoped);

			if (isScoped) {
				StartCoroutine (OnScoped ());
			}
			else
				OnUnscoped();
		}
		if (isScoped && Input.GetAxis ("Mouse Scrollwheel") > 0f) 
		{
			if (mycamera.fieldOfView > 1) 
			{
				mycamera.fieldOfView--; 
			}
		}
		if (isScoped && Input.GetAxis ("Mouse Scrollwheel") < 0f) 
		{
			if (mycamera.fieldOfView < 100) 
			{
				mycamera.fieldOfView++;
			}
		}
	}

	void OnUnscoped () 
	{
		mycamera.fieldOfView = fov;
		scopeOverlay.SetActive (false);
		sniper.SetActive (true);
	}

	IEnumerator OnScoped ()
	{
		yield return new WaitForSeconds (.15f);
		scopeOverlay.SetActive (true);
		sniper.SetActive (false);
	}

}
