using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pelaajien nimen näkyminen moninpelissä. Ei toimi tällä hetkellä
public class NameTag : Photon.MonoBehaviour {
    
	// Use this for initialization
	void Start ()
    {
        GetComponent<TextMesh>().text = PhotonNetwork.playerName;
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
}
