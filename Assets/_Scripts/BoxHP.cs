using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHP : MonoBehaviour {
	public float hp = 100;
	private Shooting shooting;
	public bool damaged;

	// Use this for initialization
	void Start () {
		shooting = GameObject.Find("Player").GetComponent<Shooting> ();
	}
	
	// Update is called once per frame
	void Update () {
		damaged = false;
		if (shooting.hit) {
			hp -= 10;
			damaged = true;

			if (hp < 0) {
				print ("dead");
			
			}
		}
	}
}

