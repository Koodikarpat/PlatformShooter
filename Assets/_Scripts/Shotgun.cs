using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : BaseWeapon{

	public int shotGunPellets;


	public override void Fire (Vector3 origin, Vector3 direction) {
	
		base.Fire (origin, direction);	

		if (canFire == true && currentAmmo > 0 && !reloading) {
		
			muzzleFlash.Play ();
			timer = 0;
			currentAmmo -= 1;
			CheckHits (origin, direction);
			StartCoroutine (ShotEffect());

			Vector3 rayOrigin = mainCamera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0f));
			RaycastHit hit;

			bulletTracer.SetPosition (0, gunEnd.position);

			if (Physics.Raycast (rayOrigin, SprayAndPray (), out hit, weaponRange)) {
				bulletTracer.SetPosition(1, hit.point);
			} else {	
				bulletTracer.SetPosition(1, rayOrigin + (mainCamera.transform.forward * weaponRange));
			}

			recoilOffsetY = 2.5f * firerate / 1.0f;
			transform.parent.parent.GetComponent<CameraControl> ().offsetY += recoilOffsetY;
		}
	
	}
















}