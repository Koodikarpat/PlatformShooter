using UnityEngine;
using System.Collections;

//Hoitaa kameran ohjaamisen hiirellä
public class CameraControl : MonoBehaviour {

	bool followOnStart = false;
	bool isFollowing;
	public float mouseSensitivity;      //Määrää kameran liikkumisnopeuden
    public bool cursorlocked;           //Tarkistaa, onko hiiren kursori lukittuna paikoilleen

	public float maxXAngle = 90f;
	public float minXAngle = -45f;
	public float offsetY;		//how much the crosshair moves upwards when a bullet is shot (variable comes from baseweapon script)

    private float rotY = 0.0f;
    private float rotX = 0.0f;
    public GameObject vertical;     //Vertical-Gameobject mahdollistaa kameran liikuttamisen pystysuorasti ilman että hahmo liikkuu sen mukana

	void Start ()
	{
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
		//gameObject.GetComponent<BaseWeapon> ();
	
	}

    //Kameran liikuttaminen
	void Update ()
	{

		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = -Input.GetAxis ("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;
		rotX = Mathf.Clamp (rotX, minXAngle, maxXAngle);// rajoittaa kameran liikkeen ylös/alas
		Quaternion horizontalRotation = Quaternion.Euler (0.0f, rotY, 0.0f);
		transform.rotation = horizontalRotation;
		Quaternion verticalRotation = Quaternion.Euler (rotX - offsetY, 0.0f, 0.0f);
		vertical.transform.localRotation = verticalRotation;

		if (offsetY > 0f) 
		{
			offsetY += -0.05f;
		}

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
	}
}