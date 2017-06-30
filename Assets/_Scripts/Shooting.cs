using UnityEngine;
using System.Collections;

//Kutsuu Weapon-scriptin funktioita
public class Shooting : MonoBehaviour {
	
	public BaseWeapon weapon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();
        }
    }

}


