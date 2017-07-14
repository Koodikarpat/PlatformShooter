using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseWeapon : MonoBehaviour
{


    public ParticleSystem muzzleFlash;		//visual flash when you shoot the gun
    public float firerate;
	public int damage;
    public float timer;
    public bool canFire;
    public bool reloading = false;
    public float reloadTime;
	public int maxAmmo;
    public int currentAmmo;
	public AudioSource reloadSound;

	public Text ammocount;
	public Slider ammoslider;
	BaseWeapon currentWeapon;

	public bool automaticRifle;        //if your gun is a machine gun etc enable this option
	public static float recoilOffsetY;
	public int range;

	public AudioSource gunAudio;					//shooting sound
	public WaitForSeconds tracerLifetime = new WaitForSeconds(0.5f);		//how long bullet tracer will be visible
	public Transform gunEnd;		//end of the gun, where the tracer comes from (place gameobject at the end of the gun)
	public float weaponRange;		//how far the gun can shoot
	public float shotSpread;		//how bad the bullets spread when shot (bigger is badder, duh) 0,05 is a good starting value
	public int maxBulletsPerClick;         //if you have a shotgun, burst rifle etc
	public int shotsFired;

	public Camera mainCamera;
	public LineRenderer bulletTracer;

    
	public void CheckHits(Vector3 origin, Vector3 direction)
    {
        Vector3 tempPos = transform.position - transform.right * 0.3f; //jostain syystä pistoolin model ei oo keskellä transformia
        Debug.DrawRay(tempPos, direction, Color.red, 2f);
        Debug.DrawRay(origin, direction, Color.green, 2f);
        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, weaponRange))
        {
            if (hit.transform.gameObject.layer == gameObject.layer || (hit.transform.gameObject.layer != 8 && hit.transform.gameObject.layer != 9)) return;
            hit.transform.gameObject.GetComponent<BoxHP>().TakeDamage(damage);
        }
    }

    public virtual void Reload()
    {		
		if (Input.GetKeyDown (KeyCode.R) && currentAmmo == maxAmmo) {
			reloading = false;
		}
		else
			StartCoroutine(ReloadThread());

    }
    private IEnumerator ReloadThread()
    {
		
	
        reloading = true;
        Debug.Log("Reload");

		if (reloadSound != null) reloadSound.Play ();

        yield return new WaitForSeconds(reloadTime);

		currentAmmo = maxAmmo;
        reloading = false;
		Debug.Log ("Reloaded");

    }
    public virtual void Fire(Vector3 origin, Vector3 direction)
    {
		//Debug.Log (canFire + " " + reloading + " " + currentAmmo);
		if (canFire == true && currentAmmo > 0 && !reloading)
        {
			Vector3 rayOrigin = mainCamera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0f));

			if (Physics.Raycast (rayOrigin, mainCamera.transform.forward, out hit, weaponRange)) {
			
				//Debug.Log ("Fire() toimii?");
				SprayAndPray ();
				muzzleFlash.Play ();
				timer = 0;
				currentAmmo -= 1;
				CheckHits (origin, direction);
				StartCoroutine (ShotEffect ());

				//Vector3 rayOrigin = mainCamera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0f));

				bulletTracer.SetPosition (0, gunEnd.position);

				if (Physics.Raycast (origin, SprayAndPray (), out hit, weaponRange)) {
					bulletTracer.SetPosition (1, hit.point);	
				} else {
					bulletTracer.SetPosition (1, origin + (direction * weaponRange));
				}
				
				recoilOffsetY = 2.5f * firerate / 1.0f;
				//transform.parent.Rotate (Vector3.right * recoilOffsetY);
				//transform.parent.parent.GetComponent<CameraControl> ().offsetY += recoilOffsetY;
				Debug.Log ("Recoil on" + recoilOffsetY);
				//recoilOffsetY = - 2.5f * firerate /1.0f;
				//transform.parent.parent.GetComponent<CameraControl> ().offsetY += recoilOffsetY;
			}

        }
    }

	/*
	 * loop until->
	 * get direction
	 * set spread (voi myös olla no spread) with random
	 * */

    void Start()
    {
		
		GameObject Player = GameObject.Find ("Player");
		Shooting Shooting = Player.GetComponent<Shooting> ();
        canFire = true;
		currentAmmo = maxAmmo; 
		//mainCamera = GetComponentInParent<Camera> ();



    }

    void Update()
    {
        timer += Time.deltaTime;
        canFire = timer > firerate;


		GameObject Player = GameObject.Find ("Player");
		BoxHP BoxHP = Player.GetComponent<BoxHP> ();

		GameObject Pistol = GameObject.Find ("Pistol");
		Shooting Shooting = Player.GetComponent<Shooting> ();

		if (BoxHP.currenthp <= 0)
		{
			Shooting.secondary.SetActive (false);
			Shooting.primary.SetActive (true);
			currentWeapon = Shooting.primary.GetComponent <BaseWeapon> ();
			currentWeapon.currentAmmo = 15; //currentWeapon.maxAmmo;
			canFire = false;
			Debug.Log (canFire + " " + reloading + " " + currentAmmo + currentWeapon);
			Shooting.secondary.SetActive (false);
			Shooting.primary.SetActive (true);
			canFire = true;
			currentWeapon.currentAmmo = 15;

		}

		if (currentWeapon = Shooting.primary.GetComponent <BaseWeapon> ()) 
		{
			
			canFire = true;
			Shooting.secondary.SetActive (false);
		}
	
	}
	public IEnumerator ShotEffect()
	{
        if (gunAudio != null) gunAudio.Play();
        if (bulletTracer != null) bulletTracer.enabled = true;
		yield return tracerLifetime;
        if (bulletTracer != null) bulletTracer.enabled = false;
	}


	public Vector3 SprayAndPray() 		//aka shooting is inaccurate
	{
		float vz = 1.0f;
		float vx = (1 - 2 * Random.value) * shotSpread;
		float vy = (1 - 2 * Random.value) * shotSpread;
		Vector3 direction = transform.TransformDirection (new Vector3 (vx, vy, vz));
		//Debug.Log (direction);
		return direction;
	}
		




}
