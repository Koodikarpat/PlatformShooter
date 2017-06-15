using UnityEngine;
using System.Collections;

//Hoitaa kameran ohjaamisen hiirellä
public class CameraControl : MonoBehaviour {

<<<<<<< HEAD

	bool followOnStart = false;
	public float mouseSensitivity;
	bool isFollowing;
    private float rotY = 0.0f;
    private float rotX = 0.0f;
    public GameObject vertical;
	Transform cameraTransform;
=======
	public float mouseSensitivity;      //Määrää kameran liikkumisnopeuden
    public bool cursorlocked;           //Tarkistaa, onko hiiren kursori lukittuna paikoilleen

    private float rotY = 0.0f;
    private float rotX = 0.0f;
    public GameObject vertical;     //Vertical-Gameobject mahdollistaa kameran liikuttamisen pystysuorasti ilman että hahmo liikkuu sen mukana

>>>>>>> edca8fe4a93bcec7e639e47f95a7f908da01d4fd
	void Start ()
	{
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;


	}

    //Kameran liikuttaminen
	void Update ()
<<<<<<< HEAD
	{

		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = -Input.GetAxis ("Mouse Y");
=======
    { 
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");
>>>>>>> edca8fe4a93bcec7e639e47f95a7f908da01d4fd

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		Quaternion horizontalRotation = Quaternion.Euler (0.0f, rotY, 0.0f);
		transform.rotation = horizontalRotation;
<<<<<<< HEAD



		Quaternion verticalRotation = Quaternion.Euler (rotX, 0.0f, 0.0f);
		vertical.transform.localRotation = verticalRotation;

	
		// we don't smooth anything, we go straight to the right camera shot
=======
        Quaternion verticalRotation = Quaternion.Euler(rotX, 0.0f, 0.0f);
        vertical.transform.localRotation = verticalRotation;


        //Mahdollistaa hiiren muuttamisen näkyväksi ja näkymättömäksi pelin aikana
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
		}
>>>>>>> edca8fe4a93bcec7e639e47f95a7f908da01d4fd

	}




}