using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	void Start ()
    {
	
	}
	
	void Update ()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

	if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(transform.position, forward, 10, LayerMask.GetMask("Player")))
            {
                print("Hit!");
            }
        }
	}
}
