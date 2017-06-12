using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Checkbox2 : MonoBehaviour {

	public Weapon pickweapon;

	public void Checked(){
		pickweapon = GameObject.Find ("Player").GetComponent<Weapon> ();	
		pickweapon.primaryWeapon = 1;
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


	}
}