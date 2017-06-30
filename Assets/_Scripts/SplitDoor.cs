using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitDoor : MonoBehaviour
{

    public bool open;      //Tarkistaa, onko ovi avattu
    private bool enter;     //Tarkistaa, pystyykö pelaaaja avaamaan tai sulkemaan oven
    public float SecondsForOneLenght;
    public float Timer = 0;
    public float TimeOpen;
    private Vector3 Startpoint;
    public Vector3 Endpoint;
    public Transform FarEnd;
    public bool Returns;
    private bool Returning = false;

    void Start()
    {
        Startpoint = transform.position;
        if (Returns)
            TimeOpen /= 2;
        if (FarEnd != null)
            Endpoint = FarEnd.position;
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.E) && !open && enter)
            {
                open = true;
            }

            if (open == true)
            {
                if (Returning)
                    Timer -= Time.deltaTime;
                else
                    Timer += Time.deltaTime;

                if (Timer > SecondsForOneLenght + TimeOpen)
                {
                    Returning = true;
                }
                else if (Timer > SecondsForOneLenght)
                    return;
                else
                {
                    transform.position = Vector3.Lerp(Startpoint, Endpoint, Mathf.SmoothStep(0f, 1f, Mathf.PingPong((Timer / SecondsForOneLenght), 1f)));
                }

                if (Timer < 0)
                {
                    open = false;
                    Timer = 0;
                    Returning = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)

    {
        Debug.Log("Door Enter");

        if (other.gameObject.tag == "Player")
        {
            enter = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = false;
        }
    }
}
