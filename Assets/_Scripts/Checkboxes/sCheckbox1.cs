using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sCheckbox1 : MonoBehaviour {

	public Weapon pickweapon;

	public void Checked2(){
		pickweapon = GameObject.Find ("Player").GetComponent<Weapon> ();	
		pickweapon.secondaryWeapon = 0;
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


	}
}