using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hoitaa ammusten ja puukotuksen osumisen siihen mihin kamera osoittaa
public class Aiming : MonoBehaviour {
	public BoxHP boxihp;
    private int shotgunPellets = 7;
    private Vector3 localOffset;

	public void CheckHits()
    {
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		boxihp = GameObject.Find ("Enemy").GetComponent<BoxHP> ();
            if (Physics.Raycast(transform.position, forward, 100, LayerMask.GetMask("Player")))
            {
                print("Hit!");
                boxihp.TakeDamage(10);
            }
    }

    public void KnifeCheckHits()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        boxihp = GameObject.Find("Enemy").GetComponent<BoxHP>();
        if (Physics.Raycast (transform.position, forward, 7, LayerMask.GetMask("Player")))
        {
            print("Stab!");
            boxihp.TakeDamage(15);
        }
    }
}
