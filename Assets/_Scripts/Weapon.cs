using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	private Shooting shooting;
	private ChangeWeapon changeweapon;
	public float firerate;
	public float timer;
	public bool canfire;
	public int weaponclass;
	public int defaultrate;





	// Use this for initialization
	void Start () {
		
		defaultrate = 4;
		canfire = true;
		shooting = GetComponent<Shooting> ();
		changeweapon = GetComponent<ChangeWeapon> ();
		weaponclass = changeweapon.ase;
	    
	}

	// Update is called once per frame
	void Update () {

		weaponclass = changeweapon.ase;
		firerate = defaultrate - weaponclass;
		timer += Time.deltaTime;
		if (shooting.shotsfired)
			timer = 0;

		if (timer < firerate)
			canfire = false;
		else
			canfire = true; 




		}
	}

