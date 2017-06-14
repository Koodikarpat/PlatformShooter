using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float mouseSensitivity;
<<<<<<< HEAD
    public bool cursorlocked;

=======
	private bool cursorlocked;
>>>>>>> 871ab4894cee7e33eca6b74a2e1388d4c3d9e0e3
    private float rotY = 0.0f;
    private float rotX = 0.0f;
    public GameObject vertical;

	void Start ()
	{
		
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
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

<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (cursorlocked)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                cursorlocked = false;
            }
            else
            { 
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                cursorlocked = true;
            }
=======
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if (cursorlocked == true) {
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				cursorlocked = false;
			}
			else 
				Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			cursorlocked = true;
>>>>>>> 871ab4894cee7e33eca6b74a2e1388d4c3d9e0e3
		}

	}
}