﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour {

    public BaseWeapon weapon;
    Enemy enemyScript;
    public float range;
    public float fireRate;
    public float reflexDelay;
    bool readyToShoot;
    float time;
    Vector3 direction;

    // Use this for initialization
    void Start () {

        enemyScript = GetComponent<Enemy>();
        range = weapon.weaponRange;
        readyToShoot = false;

	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        if (range != weapon.weaponRange) range = weapon.weaponRange;

        if (enemyScript.inCombat && time >= fireRate)
        {
            if (!readyToShoot)
            {
                direction = weapon.transform.TransformDirection(Vector3.forward) * range;
                readyToShoot = true;
            }
            if (time >= fireRate + reflexDelay && readyToShoot)
            {
                weapon.Fire(weapon.transform.position, direction);
                time = 0;
                readyToShoot = false;
            }
        }

        if (weapon.currentAmmo == 0)
        {
            weapon.Reload();
        }
    }
}
