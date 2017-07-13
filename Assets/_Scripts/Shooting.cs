using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Kutsuu Weapon-scriptin funktioita
public class Shooting : MonoBehaviour {
	
	public GameObject primary;   //change weapon
	public GameObject secondary;
	BaseWeapon currentWeapon;
	public float MaxSpread = 0.3f;
	public float MinSpread = 0.1f;
    public GameObject camera;
    public Text ammoText;

	void Start () {
	
		primary.SetActive(true);
		secondary.SetActive(false);
		currentWeapon = primary.GetComponent<BaseWeapon> ();

		ammoText.text = currentWeapon.maxAmmo + "/" + currentWeapon.maxAmmo;
        Debug.Log (currentWeapon);
	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Mouse0) || (Input.GetKey(KeyCode.Mouse0) && currentWeapon.automaticRifle))
        {
            Vector3 direction = camera.transform.TransformDirection(Vector3.forward) * currentWeapon.weaponRange;
            currentWeapon.Fire(camera.transform.position, direction);
            ammoText.text = currentWeapon.currentAmmo + "/" + currentWeapon.maxAmmo;
        }
			

        if (Input.GetKeyDown(KeyCode.R))
        {
			StartCoroutine(Reload());
        }

		if (Input.GetKeyDown(KeyCode.Alpha1)) 
		{
			secondary.SetActive(false);
			primary.SetActive(true);
			currentWeapon = primary.GetComponent<BaseWeapon> ();
            ammoText.text = currentWeapon.currentAmmo + "/" + currentWeapon.maxAmmo;
        }

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			primary.SetActive(false);
			secondary.SetActive(true);
			currentWeapon = secondary.GetComponent<BaseWeapon> ();
            ammoText.text = currentWeapon.currentAmmo + "/" + currentWeapon.maxAmmo;
        }
			


    }

	public IEnumerator Reload()
	{
		currentWeapon.Reload ();
		yield return new WaitForSeconds (currentWeapon.reloadTime);
		ammoText.text = currentWeapon.currentAmmo + "/" + currentWeapon.maxAmmo;
	}
}