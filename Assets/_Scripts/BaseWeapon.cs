using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseWeapon : MonoBehaviour
{

	public ParticleSystem muzzleFlash;
    public int damage;
	public float firerate;
	public float timer;
	public bool canFire;
	public bool reloading = false;
	public float reloadTime;
	public int maxAmmo;
	public int currentAmmo;
	public AudioSource reloadSound;
	public float range;


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
        Vector3 forward = transform.TransformDirection(Vector3.forward) * range;
        Vector3 tempPos = transform.position - transform.right * 0.3f; //jostain syystä pistoolin model ei oo keskellä transformia
        Debug.DrawRay(tempPos, forward, Color.red, 5f);
       /* Boxhp = GameObject.Find("Enemy").GetComponent<BoxHP>();
        if (Physics.Raycast(transform.position, forward, 200, LayerMask.GetMask("Player")))
        {
            Debug.Log("Hit");
            Boxhp.TakeDamage();
        }*/
    }

    public virtual void Reload()
    {
        StartCoroutine(ReloadThread());
    }
    private IEnumerator ReloadThread()
    {
        reloading = true;
        //Debug.Log("Reload");
		if (reloadSound != null) reloadSound.Play ();

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        reloading = false;
		//Debug.Log ("Reloaded");
    }
    public virtual void Fire()
    {
		//Debug.Log (canFire + " " + reloading + " " + currentAmmo);
		if (canFire == true && currentAmmo > 0 && !reloading)
        {
            muzzleFlash.Play();
            timer = 0;
            currentAmmo -= 1;
            //print(currentAmmo);
            CheckHits();
			StartCoroutine (ShotEffect());
            Vector3 rayOrigin;
            if (mainCamera != null) rayOrigin = mainCamera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0f));
			RaycastHit hit;

            if (bulletTracer != null) bulletTracer.SetPosition (0, gunEnd.position);

			//if (Physics.Raycast (rayOrigin, mainCamera.transform.forward, out hit, weaponRange)) {
   //             if (bulletTracer != null) bulletTracer.SetPosition (1, hit.point);	
			//} 

			//else 
			//{
   //             if (bulletTracer != null) bulletTracer.SetPosition(1, rayOrigin + (mainCamera.transform.forward * weaponRange));
			//}

        }
    }

    void Start()
    {
        canFire = true;
        currentAmmo = maxAmmo; 
		//mainCamera = GetComponentInParent<Camera> ();
    }

    void Update()
    {
        timer += Time.deltaTime;
        canFire = timer > firerate;
		Debug.Log (mainCamera);
		GameObject.Find ("Player/CrosshairCanvas/BulletCount").GetComponent<Text>().text = currentAmmo + "/" + maxAmmo + "    ";
    }

	public IEnumerator ShotEffect()
	{
        if (gunAudio != null) gunAudio.Play();
        if (bulletTracer != null) bulletTracer.enabled = true;
		yield return tracerLifetime;
        if (bulletTracer != null) bulletTracer.enabled = false;
	}

	void SprayAndPray() 
	{
		
	}

}