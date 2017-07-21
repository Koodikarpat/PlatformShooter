using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knife : BaseWeapon
{
    public BoxHP boxihp;



    public override void Fire(Vector3 origin, Vector3 direction)
    {
        base.Fire(origin, direction);

        if (canFire == true)
        {
            Vector3 forward = transform.parent.parent.TransformDirection(Vector3.forward) * 10;

            if (Physics.Raycast(transform.position, forward, 7, LayerMask.GetMask("Player")))
				boxihp = GameObject.Find("Enemy").GetComponent<BoxHP>();
            {
				boxihp.StabDamage();
				Debug.Log("Stab!");
			
               
            }
            timer = 0;
        }
    }

    public override void Reload()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;
        canFire = timer > firerate;
    }


}
