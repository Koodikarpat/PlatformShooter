using UnityEngine;
using System.Collections;

//Kutsuu Weapon-scriptin funktioita
public class Shooting : MonoBehaviour {
	



	private Weapon weapon;

	void Awake(){
		weapon = GetComponent<Weapon> (); 


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


