using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseWeapon : MonoBehaviour
{

    public ParticleSystem muzzleFlash;
    public float firerate;
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


	public AudioSource gunAudio;						//shooting sound
	public WaitForSeconds tracerLifetime = new WaitForSeconds(0.07f);		//how long bullet tracer will be visible
	public Transform gunEnd;		//end of the gun, where the tracer comes from
	public float weaponRange;

	public Camera mainCamera;
	public LineRenderer bulletTracer;   //private????

	private float vx;
	private float vy;
	private float vz = 1.0f;
    
	public void CheckHits()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
       /* Boxhp = GameObject.Find("Enemy").GetComponent<BoxHP>();
        if (Physics.Raycast(transform.position, forward, 200, LayerMask.GetMask("Player")))
        {
            Debug.Log("Hit");
            Boxhp.TakeDamage();
        }*/
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
		//reloadSound.Play ();

        yield return new WaitForSeconds(reloadTime);

		currentAmmo = maxAmmo;
        reloading = false;
		Debug.Log ("Reloaded");

    }
    public virtual void Fire()
    {
		Debug.Log (canFire + " " + reloading + " " + currentAmmo);
		if (canFire == true && currentAmmo > 0 && !reloading)
        {
			Debug.Log ("Fire() toimii?");
            muzzleFlash.Play();
            timer = 0;
            currentAmmo -= 1;



            print(currentAmmo);
            CheckHits();
			//StartCoroutine (ShotEffect());
			Vector3 rayOrigin = mainCamera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0f));
			RaycastHit hit;

			bulletTracer.SetPosition (0, gunEnd.position);

			if (Physics.Raycast (rayOrigin, mainCamera.transform.forward, out hit, weaponRange)) {
				bulletTracer.SetPosition (1, hit.point);	
			} 

			else 
			{
				bulletTracer.SetPosition(1, rayOrigin + (mainCamera.transform.forward * weaponRange));
			}

        }
    }

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
		Debug.Log (mainCamera);

		GameObject Player = GameObject.Find ("Player");
		BoxHP BoxHP = Player.GetComponent<BoxHP> ();

		GameObject Pistol = GameObject.Find ("Pistol");
		Shooting Shooting = Player.GetComponent<Shooting> ();



		{
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
	
	}
	public IEnumerator ShotEffect()
	{
		Debug.Log ("ShotEffect toimii?");
		gunAudio.Play ();
		bulletTracer.enabled = true;
		yield return tracerLifetime;
		bulletTracer.enabled = false;
	}



	void SprayAndPray() 
	{
		
	}




}
