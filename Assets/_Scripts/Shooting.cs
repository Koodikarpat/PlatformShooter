using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	



	private Weapon weapon;

	public bool hit;

	void Awake(){
		weapon = GetComponent<Weapon> (); 



	} 
	void Start ()
    {
		
	}
	
	void Update ()
    {
		

        
			if (Input.GetKeyDown (KeyCode.Mouse0)){
			weapon.Shoot ();

			}

		if (Input.GetKeyDown (KeyCode.R))
			weapon.Reload ();
			}

}


