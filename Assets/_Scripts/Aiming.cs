<<<<<<< HEAD
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
=======
﻿using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour
{
    public BoxHP boxihp;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
>>>>>>> a9ee653bd1bb2e786f0eaed29efeef7e32b03a63
}
