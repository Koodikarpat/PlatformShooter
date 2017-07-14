using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour {

	public Slider healthslider;
	public Text healthtext;


	void Start () {
		
	}
	

	void Update () {
		

	}

	public void SetHealthText()
	{

		GameObject Player = GameObject.Find ("Player");
		BoxHP BoxHP = Player.GetComponent<BoxHP> ();

		healthtext.text = "HP: " + BoxHP.currenthp.ToString () + "/" + BoxHP.maxhp.ToString ();

		healthslider.value = BoxHP.currenthp;
	}

}


