<<<<<<< HEAD

using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour
{
    public BoxHP boxihp;

    public void CheckHits()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        boxihp = GameObject.Find("Cube").GetComponent<BoxHP>();
        if (Physics.Raycast(transform.position, forward, 100, LayerMask.GetMask("Player")))
        {
            print("Hit!");
            boxihp.TakeDamage();
        }
    }
    
   
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hoitaa ammusten osumisen siihen mihin kamera osoittaa
public class Aiming : MonoBehaviour {
	public BoxHP boxihp;

	public void CheckHits(){
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		boxihp = GameObject.Find ("Cube").GetComponent<BoxHP> ();
		if (Physics.Raycast (transform.position, forward, 100, LayerMask.GetMask ("Player"))) {
>>>>>>> edca8fe4a93bcec7e639e47f95a7f908da01d4fd


<<<<<<< HEAD

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

﻿



    

   
    }


   



=======
		}
	}   
}
>>>>>>> edca8fe4a93bcec7e639e47f95a7f908da01d4fd
