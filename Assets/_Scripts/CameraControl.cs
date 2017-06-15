using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {


	bool followOnStart = false;
	public float mouseSensitivity;
	bool isFollowing;
    private float rotY = 0.0f;
    private float rotX = 0.0f;
    public GameObject vertical;
	Transform cameraTransform;
	void Start ()
	{
		
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;


	}

	void Update ()
	{

		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = -Input.GetAxis ("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		Quaternion horizontalRotation = Quaternion.Euler (0.0f, rotY, 0.0f);
		transform.rotation = horizontalRotation;



		Quaternion verticalRotation = Quaternion.Euler (rotX, 0.0f, 0.0f);
		vertical.transform.localRotation = verticalRotation;

	
		// we don't smooth anything, we go straight to the right camera shot

	}




}