using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour 
{
	public int startingHealth = 100;
	public int currentHealth;
	public int maxHealth = 100;
	public int minHealth = 0;



	// Use this for initialization
	void Start () 
	{
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Damage")) 
		{
			currentHealth = currentHealth - 10;
			if (currentHealth <= minHealth) 
			{
				currentHealth = minHealth;
			}
		}
		if (other.gameObject.CompareTag ("HP")) 
		{
			currentHealth = currentHealth + 20;
			if (currentHealth >= maxHealth)
			{
				currentHealth = maxHealth;
			}
		}
	}

}
	
