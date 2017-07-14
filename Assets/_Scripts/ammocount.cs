using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammocount : MonoBehaviour {


	public Text ammotext;
	public Slider ammoslider;
	BaseWeapon currentWeapon;

	void Start () {
		
	}
	

		void Update () {
		
		SetAmmoText ();

	}
	public void SetAmmoText()
	{

		BaseWeapon BaseWeapon = GetComponent<BaseWeapon> ();


		{
			if (BaseWeapon.maxAmmo >= 0)
				ammotext.text = "Ammo: " + BaseWeapon.currentAmmo.ToString () + "/" + BaseWeapon.maxAmmo.ToString ();

			ammoslider.value = BaseWeapon.currentAmmo;

		}
		if (BaseWeapon.currentAmmo <= 0)
		{
			ammotext.text = "Knife";
		}

		if (BaseWeapon.currentAmmo == 0)
		{
			ammotext.text = "No ammo, reload (R)";
		}
		if(BaseWeapon.reloading == true)
		{
			ammotext.text = "Reloading...";
		}
		if (BaseWeapon.maxAmmo <= 0)
		{
			ammotext.text = "Knife";
		}

	}


}
