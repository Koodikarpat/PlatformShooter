using System.Collections.Generic;
using UnityEngine;

public class Shotgun : BaseWeapon{

	private float randomX;
	private float randomY;
	private Vector3 localOffset;
	private Vector3 bulletSpread;
	//public ParticleSystem hitEffect;

	public override void Fire(Vector3 origin, Vector3 direction) {

		if (canFire == true && currentAmmo > 0 && !reloading) {
			currentAmmo -= 1;
			for (int count = 0; count < maxBulletsPerClick; count++) {

				muzzleFlash.Play ();
				timer = 0;

			

				Vector3 rayOrigin = mainCamera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0f));		//shoudl set raycast origin to the center of the screen
				RaycastHit hit;


				if (Physics.Raycast (rayOrigin, SprayAndPray(), out hit, weaponRange)) {
					Instantiate(hitEffect, hit.point, Quaternion.identity);
					Debug.Log ("test");
				} else {	
					
				}

				if (gunAudio != null) gunAudio.Play();
				recoilOffsetY = 2.5f * firerate / 1.0f;
				transform.parent.parent.GetComponent<CameraControl> ().offsetY += recoilOffsetY;
				shotsFired++;
				CheckHits (origin, direction);

			}

		}

		else {
			if (reloadSound != null && !reloading && currentAmmo <= 0)
				reloadSound.Play ();
		}

	}


}