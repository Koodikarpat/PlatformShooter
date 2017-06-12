using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHP : MonoBehaviour {
	public float hp = 100;

	public void TakeDamage(){
		hp -= 10;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


			if (hp < 0) {
				transform.position = new Vector3(5f, 0.5f, 7f);
				hp = 100;
			print ("dead");
			}
		}
	}


