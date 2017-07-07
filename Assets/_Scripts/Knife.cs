using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : BaseWeapon
{
    public BoxHP boxihp;

    public override void Fire()
    {
        base.Fire();

        if (canFire == true)
        {
            Vector3 forward = transform.parent.parent.TransformDirection(Vector3.forward) * 10;
            boxihp = GameObject.Find("Enemy").GetComponent<BoxHP>();
            if (Physics.Raycast(transform.position, forward, 7, LayerMask.GetMask("Player")))
            {
                Debug.Log("Stab!");
                boxihp.TakeDamage(damage);
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
