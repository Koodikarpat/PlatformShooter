using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimney : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void OnTriggerEnter(Collider player) {
		if (player.transform.position.y < 10){
			player.transform.position = new Vector3(-0.113f, 29.293f, -19.824f);
			}
		else{
			player.transform.position = new Vector3(-4.89f, 1.55f, -19.824f);

			}

	}

}