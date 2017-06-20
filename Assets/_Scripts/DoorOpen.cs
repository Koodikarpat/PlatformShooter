using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    public float smooth;        //Määrää oven avautumisnopeuden
    public float DoorOpenAngle;     //Oven kulma, kun se on auki
    public float DoorCloseAngle;        //Oven kulma, kun se on kiinni
    private bool open;      //Tarkistaa, onko ovi avattu
    private bool enter;     //Tarkistaa, pystyykö pelaaaja avaamaan tai sulkemaan oven

	void Update ()
    {
        //Oven avaaminen ja sulkeminen
        if (open == true)
        {
            Quaternion target = Quaternion.Euler(0, DoorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
        }

        if (open == false)
        {
            Quaternion target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * smooth);
        }

        if (enter == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                open = !open;
            }
        }
	}

    //Tarkistavat, onko pelaaja tarpeeksi lähellä ovea, jotta sen voi avata
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = false;
        }
    }
}
