using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hoitaa ammusten osumisen siihen mihin kamera osoittaa
public class Aiming : MonoBehaviour {
	public BoxHP boxihp;

	public void CheckHits(){
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		boxihp = GameObject.Find ("Cube").GetComponent<BoxHP> ();
		if (Physics.Raycast (transform.position, forward, 100, LayerMask.GetMask ("Player"))) {

			print ("Hit!");
			boxihp.TakeDamage ();

		}
	}   
}
