using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    public float smooth;
    public float DoorOpenAngle;
    public float DoorCloseAngle;
    private bool open;
    private bool enter;

	void Update ()
    {
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
