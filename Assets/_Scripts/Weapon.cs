using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	private Shooting shooting;
    public Aiming aiming;
	public BoxHP boxihp;
	public float firerate;
	public float timer;
	public bool canfire;
	public int weaponclass;
	public int defaultrate;

	private bool[] automaticPrimary = new bool[]{true,true,false};
	private bool[] automaticSecondary = new bool[]{ false, false, true };



	public int selectedWeapon = 0;
	public int primaryWeapon = 0;
	public int secondaryWeapon = 0;


	private float[] primaryFireclass = new float[]{0.5f, 0.7f, 0.5f};                                                                                                              
	private float[] secondaryFireclass = new float[]{0.5f, 0.7f, 0.5f};

	public static int[] primaryMaxammo = new int[]{10, 20, 30};
	public int[] primaryCurrentammo = new int[]{10, 20, 30};
	public static int[] secondaryMaxammo = new int[]{12,20,50};
	public int[] secondaryCurrentammo = new int[]{12,20,50};


	public void ChangeWeapon(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			selectedWeapon = 0;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			selectedWeapon = 1;
		}
	}
	
	public void ShootPrimary(){
		
			if (canfire == true && primaryCurrentammo [primaryWeapon] > 0) {

				print ("pum");
				timer = 0;
				primaryCurrentammo [primaryWeapon] -= 1;
				print (primaryCurrentammo [primaryWeapon]);
			}
			
			

	}

	void ShootSecondary(){
		
			if (canfire == true && primaryCurrentammo [primaryWeapon] > 0) {

				print ("pum");
				timer = 0;
				secondaryCurrentammo [secondaryWeapon] -= 1;
				print (secondaryCurrentammo [secondaryWeapon]);
			}
			
			
		}


	

	public void Shoot() {

		if (selectedWeapon == 0){
			ShootPrimary ();

			aiming.CheckHits ();

		}
		else{
			ShootSecondary ();

			aiming.CheckHits ();


		}
	}



	public void Reload(){
		print ("reloading");
		if (selectedWeapon == 0) {
			
			primaryCurrentammo [primaryWeapon] = primaryMaxammo [primaryWeapon];
		} else {
			secondaryCurrentammo [secondaryWeapon] = secondaryMaxammo [secondaryWeapon];
		}
	}

	// Use this for initialization
	void Start () {
		
		defaultrate = 1;
		canfire = true;



	}

	// Update is called once per frame
	void Update () {
		ChangeWeapon ();

		if (selectedWeapon == 0) {
			

			firerate = defaultrate - primaryFireclass [primaryWeapon];
			timer += Time.deltaTime;


			if (timer < firerate)
				canfire = false;
			else
				canfire = true; 

		} else {
			firerate = defaultrate - secondaryFireclass [secondaryWeapon];
			timer += Time.deltaTime;
		}
		if (timer < firerate)
			canfire = false;
		else
			canfire = true;
		}
	}

