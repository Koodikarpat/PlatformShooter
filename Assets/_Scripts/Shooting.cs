﻿using UnityEngine;
using System.Collections;

//Kutsuu Weapon-scriptin funktioita
public class Shooting : MonoBehaviour {
	
	public GameObject primary;   //change weapon
	public GameObject secondary;
	BaseWeapon currentWeapon;
	public float MaxSpread = 0.3f;
	public float MinSpread = 0.1f;
    public GameObject camera;

	void Start () {
	
		primary.SetActive(true);
		secondary.SetActive(false);
		currentWeapon = primary.GetComponent<BaseWeapon> ();
		Debug.Log (currentWeapon);
	}

    void Update()
    {
        //AMPUMISEN RANGE EI TOIMI VIELÄ KUNNOLLA KOSKA ETÄISYYS KAMERASTA KOHTEESEEN ON PIDEMPI KUIN ASEESTA
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 direction = camera.transform.TransformDirection(Vector3.forward) * currentWeapon.range;
            currentWeapon.Fire(camera.transform.position, direction);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            currentWeapon.Reload();
        }

		if (Input.GetKeyDown(KeyCode.Alpha1)) 
		{
			secondary.SetActive(false);
			primary.SetActive(true);
			currentWeapon = primary.GetComponent<BaseWeapon> ();
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			primary.SetActive(false);
			secondary.SetActive(true);
			currentWeapon = secondary.GetComponent<BaseWeapon> ();
		}
			


    }

}


