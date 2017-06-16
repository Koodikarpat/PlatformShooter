using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Aiming aiming;
    public BoxHP boxihp;
    public ParticleSystem muzzleFlash;
    public float firerate;
    public float timer;
    public bool canfire;
    public int weaponclass;
    public int defaultrate;
    private bool reloading = false;
    private bool[] automaticPrimary = new bool[] { true, true, false };
    private bool[] automaticSecondary = new bool[] { false, false, true };



    public int selectedWeapon = 0; //onko hahmolla kädessä primary vai secondary ase.
    public int primaryWeapon = 0; //mikä primaryase hahmolla on käytettävissä
    public int secondaryWeapon = 0;//mikä secondaryase hahmolla on käytettävissä


    //Latauksen kesto sekunteina.
    private float[] primaryReloadTime = new float[] { 2.50f, 2.50f, 3.70f };
    private float[] secondaryReloadTime = new float[] { 2.30f, 2.90f, 2.50f };

    //tulitahti on sekunteina 1 - sarjan jäsenen arvo.
    private float[] primaryFireclass = new float[] { 0.85f, 0.7f, 0.5f }; //esim 0.85f tarkoittaa 0.15sekunnin viivettä ennen seuraavaa laukausta jne.                                                                                                              
    private float[] secondaryFireclass = new float[] { 0.7752f, 0.7752f, 0.5f };



    //aseen lippaaseen mahtuvien ammusten määrä
    private static int[] primaryMaxammo = new int[] { 30, 7, 5 };
    private static int[] secondaryMaxammo = new int[] { 7, 13, 12 };

    //nykyinen ammusten määrä. arvo pienenee ammuttaessa ja kasvaa ladattaessa.
    private int[] primaryCurrentammo = new int[] { 30, 7, 5 };
    private int[] secondaryCurrentammo = new int[] { 7, 13, 12 };

    //Lataa primary aseen
    IEnumerator ReloadingPrimary()
    {
        reloading = true;
        print("reloading");
        yield return new WaitForSeconds(primaryReloadTime[primaryWeapon]);

        primaryCurrentammo[primaryWeapon] = primaryMaxammo[primaryWeapon];
        reloading = false;
    }

    //Lataa secondary aseen
    IEnumerator ReloadingSecondary()
    {
        reloading = true;
        print("reloading");
        yield return new WaitForSeconds(secondaryReloadTime[secondaryWeapon]);

        secondaryCurrentammo[secondaryWeapon] = secondaryMaxammo[secondaryWeapon];
        reloading = false;
    }


    //Hahmovalikko kutsuu näitä riippuen siitä, minkä hahmon pelaaja valitsee
    public void Shotgun()
    {
        primaryWeapon = 1;
        secondaryWeapon = 1;
    }

    public void Sniper()
    {
        primaryWeapon = 2;
        secondaryWeapon = 2;
    }

    public void Assault()
    {
        primaryWeapon = 0;
        secondaryWeapon = 0;
    }

    //Vaihtaa aseen primaryn ja secondaryn välillä
    public void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }
    }

    //Ampuu primary aseella
    public void ShootPrimary()
    {

        if (canfire == true && primaryCurrentammo[primaryWeapon] > 0 && !reloading)
        {
            muzzleFlash.Play();
            print("pum");
            timer = 0;
            primaryCurrentammo[primaryWeapon] -= 1;
            print(primaryCurrentammo[primaryWeapon]);
            aiming.CheckHits();
        }



    }

    //Ampuu secondary aseella
    void ShootSecondary()
    {

        if (canfire == true && secondaryCurrentammo[secondaryWeapon] > 0 && !reloading)
        {
            muzzleFlash.Play();
            print("pum");
            timer = 0;
            secondaryCurrentammo[secondaryWeapon] -= 1;
            print(secondaryCurrentammo[secondaryWeapon]);

            aiming.CheckHits();
        }


    }


    //Ampuu
    public void Shoot()
    {

        if (selectedWeapon == 0)
        {
            ShootPrimary();

            aiming.CheckHits();

        }
        else
        {
            ShootSecondary();


            aiming.CheckHits();

        }
    }


    //Lataa aseen
    public void Reload()
    {

        if (selectedWeapon == 0)
        {
            StartCoroutine(ReloadingPrimary());
        }
        else
            StartCoroutine(ReloadingSecondary());

    }





    void Start()
    {
        defaultrate = 1;        //Määrittää fireraten
        canfire = true;     //Voiko ampua
    }

    void Update()
    {
        ChangeWeapon();

        //Laskee fireraten valitun aseen mukaan
        if (selectedWeapon == 0)
        {


            firerate = defaultrate - primaryFireclass[primaryWeapon];
            timer += Time.deltaTime;


            if (timer < firerate)
                canfire = false;
            else
                canfire = true;

        }
        else
        {
            firerate = defaultrate - secondaryFireclass[secondaryWeapon];
            timer += Time.deltaTime;
        }
        if (timer < firerate)
            canfire = false;
        else
            canfire = true;
    }
}


