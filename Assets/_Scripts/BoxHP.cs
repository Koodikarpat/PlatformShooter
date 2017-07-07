﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Hoitaa testitarkoituksessa käytettyjen laatikkojen hp:n tarkkailusta
public class BoxHP : MonoBehaviour {
	public float hp = 100;
    public GameObject healthTextObject;
    Text healthText;

	public void TakeDamage(int damage)
    {
		hp -= damage;
	}

    //public void StabDamage()
    //{
    //    hp -= 15;
    //}

	void Start ()
    {
        healthText = healthTextObject.GetComponent<Text>();
	}

	void Update ()
    {
		if (hp <= 0)
        {
			transform.position = new Vector3(5f, 0.5f, 7f);
			hp = 100;
			print ("dead");
		}

        healthText.text = "HP:" + hp.ToString();
		}
	}


