﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed;
    public float jumpSpeed;
    public float gravity;

    private Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero;
    private bool candoublejump;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);

        if(Input.GetKeyDown(KeyCode.Space))
            if (isGrounded())
            {
                moveDirection.y = jumpSpeed;
                candoublejump = true;
            }
            else
            {
            if (candoublejump)
            {
                moveDirection.y = jumpSpeed;
                    candoublejump = false;
            }
          
            }

        moveDirection.y -= gravity * Time.deltaTime;

        rb.AddForce(moveDirection * speed);
	}

    bool isGrounded ()
    {
        Vector3 position = transform.position;
        position.y = GetComponent<Collider>().bounds.min.y + 0.1f;
        float length = 0.1f;
        Debug.DrawRay(position, Vector3.down * length);
        bool grounded = Physics.Raycast(position, Vector3.down, length, LayerMask.GetMask("Default"));
        Debug.Log(LayerMask.GetMask("default"));
        return grounded;
    }
}