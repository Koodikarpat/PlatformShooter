using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	
	public BoxHP dealtdamage;
	private Weapon weapon;
	public bool shotsfired;
	public bool hit;
	void Awake(){
		weapon = GetComponent<Weapon> ();
		dealtdamage = GameObject.Find ("Cube").GetComponent<BoxHP> ();

	} 
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
		if (dealtdamage) {
		hit = false;
		
		shotsfired = false;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

		if (Input.GetKeyDown(KeyCode.Mouse0) && weapon.canfire)
        {
			shotsfired = true;
			print ("pum");
            if (Physics.Raycast(transform.position, forward, 10, LayerMask.GetMask("Player")))
            {
				hit = true;
                print("Hit!");
            }
        }
	}
	}
}

