using UnityEngine;
using System.Collections;

//Kutsuu Weapon-scriptin funktioita
public class Shooting : MonoBehaviour {
	
	public GameObject primary;   //change weapon
	public GameObject secondary;
	BaseWeapon currentWeapon;
	public float MaxSpread = 0.3f;
	public float MinSpread = 0.1f;

	void Start () {
	
		primary.SetActive(true);
		secondary.SetActive(false);
		currentWeapon = primary.GetComponent<BaseWeapon> ();
		Debug.Log (currentWeapon);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
			Debug.Log (currentWeapon);
			currentWeapon.Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            currentWeapon.Reload();
        }

		if (Input.GetKeyDown(KeyCode.Alpha1)) 
		{
			secondary.SetActive(false);
			primary.SetActive(true);
			currentWeapon = primary.GetComponent<BaseWeapon> ();
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			primary.SetActive(false);
			secondary.SetActive(true);
			currentWeapon = secondary.GetComponent<BaseWeapon> ();
		}
			


    }

}


