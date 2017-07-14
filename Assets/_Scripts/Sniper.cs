using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : BaseWeapon 
{

	public Rigidbody projectile;
	public float speed = 50;
	new public Transform transform;

	public override void Fire (Vector3 origin, Vector3 direction)
	{
		base.Fire (transform.position, new Vector3 (0, 0, speed));
		{
			if (canFire == true && GameObject.Find ("SniperWeaponHolder").GetComponent<Scope>().isScoped && Input.GetKeyDown (KeyCode.Return)) {
				Rigidbody instantiatedProjectile = Instantiate (projectile, 
					                                  transform.position, 
					                                  transform.rotation)as Rigidbody;
				instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0,0,speed));
			}
		}
	}
	public override void Reload()
	{
	}
	void Update()
	{
		timer += Time.deltaTime;
		canFire = timer > firerate;
	}
}

