using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxHP : MonoBehaviour {
	public float hp = 100;
    public GameObject healthTextObject;
    Text healthText;

	public void TakeDamage(){
		hp -= 10;
	}
	// Use this for initialization
	void Start () {
        healthText = healthTextObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {


			if (hp <= 0) {
				transform.position = new Vector3(5f, 0.5f, 7f);
				hp = 100;
			print ("dead");
			}

        healthText.text = hp.ToString();
		}
	}


