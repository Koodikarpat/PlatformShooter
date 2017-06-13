using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float mouseSensitivity;

    private float rotY = 0.0f;
    private float rotX = 0.0f;
    public GameObject vertical;

	void Start ()
	{
		
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;

		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	void Update ()
	{
		
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		Quaternion horizontalRotation = Quaternion.Euler(0.0f, rotY, 0.0f);
		transform.rotation = horizontalRotation;

        Quaternion verticalRotation = Quaternion.Euler(rotX, 0.0f, 0.0f);
        vertical.transform.localRotation = verticalRotation;

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}