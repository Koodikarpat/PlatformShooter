using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Hoitaa testitarkoituksessa käytettyjen laatikkojen hp:n tarkkailusta
public class BoxHP : MonoBehaviour {
	public int maxhp = 100;
   
    
	public int currenthp;

	public int minhp = 0;



    public void StabDamage()
    {
        currenthp -= 100;
    }
	public void TakeDamage(int damage)
    {
		hp -= damage;
	}

	public void hpbox()
	{
		currenthp += 30;
	}
	void Start ()
    {
		

		currenthp = maxhp;
       

	}

	void Update ()
    {
		GameObject Player = GameObject.Find ("Player");
		healthbar healthbar = Player.GetComponent<healthbar> ();

		healthbar.SetHealthText ();

		GameObject Pistol = GameObject.Find ("Pistol");
		Shooting Shooting = Player.GetComponent<Shooting> ();

		if (currenthp <= 0)
        {
		
		currenthp = maxhp;



		print ("dead");
		transform.position = new Vector3(Random.Range(1f , 99f), 0.5f, Random.Range( 1f , 149f));
		}

	}


	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Damage")) {
		
		

			TakeDamage ();
		} 

			if (currenthp <= minhp) 
			{
				currenthp = minhp;

		}
		if (other.gameObject.CompareTag ("Health")) 
		{
			hpbox ();
			if (currenthp >= maxhp)
			{
				currenthp = maxhp;
			}
		}
	}


}


