﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour {

	public Rigidbody projectile;
	public float speed = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.Find("SniperWeaponHolder").GetComponent<Scope>().isScoped && Input.GetKeyDown (KeyCode.Return)) 
		{
			Rigidbody instantiatedProjectile = Instantiate (projectile, 
				                                   transform.position, 
				                                   transform.rotation)as Rigidbody;
			instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));
		}
	}
}
