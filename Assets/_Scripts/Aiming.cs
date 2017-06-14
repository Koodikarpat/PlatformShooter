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
    // Use this for initialization
    void Start()
    {
=======

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

﻿
>>>>>>> 871ab4894cee7e33eca6b74a2e1388d4c3d9e0e3


    // Use this for initialization
    

    // Update is called once per frame
    

   
    }

<<<<<<< HEAD
   
}
=======

>>>>>>> 871ab4894cee7e33eca6b74a2e1388d4c3d9e0e3
