using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

    private Vector3 Startpoint;
    public Vector3 Endpoint;
    public float SecondsForOneLenght;
    public float Timer = 0;
    public float FreezeTime;
    public bool Returns;
    private bool Returning = false ;
    public Transform farEnd;

    // Use this for initialization
    void Start() {

        Startpoint = transform.position;
        if (Returns)
            FreezeTime /= 2;
        if (farEnd != null)
            Endpoint = farEnd.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Returning)
            Timer -= Time.deltaTime;
        else
            Timer += Time.deltaTime;

        if (Timer > SecondsForOneLenght + FreezeTime || Timer < 0 - FreezeTime)

        {
            if (Returns)
            {
                Returning = !Returning;
            }
            else
            {
                Timer = 0;
            }
        }

        else if (Timer > SecondsForOneLenght || Timer < 0)
            return;
        else
        {

            transform.position = Vector3.Lerp(Startpoint, Endpoint, Mathf.SmoothStep(0f, 1f, Mathf.PingPong((Timer / SecondsForOneLenght), 1f)));

        }
    }
}
