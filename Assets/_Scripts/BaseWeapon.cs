using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        StartCoroutine(ReloadThread());
    }
    private IEnumerator ReloadThread()
    {
        reloading = true;
        Debug.Log("Reload");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        reloading = false;
    }
    public virtual void Fire()
    {
        if (canFire == true && currentAmmo > 0 && !reloading)
        {
            muzzleFlash.Play();
            timer = 0;
            currentAmmo -= 1;
            print(currentAmmo);
            CheckHits();

        }
    }

    void Start()
    {
        canFire = true;
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        timer += Time.deltaTime;
        canFire = timer > firerate;
    }
}