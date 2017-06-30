using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {

    public Vector3 EndPoint;
    public float Boost;

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger on");

        other.GetComponent<Rigidbody>().AddForce(Vector3.back*Boost, ForceMode.Acceleration);

    }


}
	