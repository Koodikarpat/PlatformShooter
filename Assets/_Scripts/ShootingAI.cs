using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour {

    public BaseWeapon weapon;
    Enemy enemyScript;
    public float range;
    public float fireRate;
    float time;

    // Use this for initialization
    void Start () {

        enemyScript = GetComponent<Enemy>();
        range = weapon.range;

	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        if (range != weapon.range) range = weapon.range;

        if (enemyScript.inCombat)
        {
            if (time >= fireRate)
            {
                weapon.Fire();
                time = 0;
            }
            if (weapon.currentAmmo == 0)
            {
                weapon.Reload();
            }
        }
	}
}
