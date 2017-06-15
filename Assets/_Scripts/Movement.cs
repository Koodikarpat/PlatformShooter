using UnityEngine;
using System.Collections;

//Hoitaa liikkumisen ja hyppimisen
public class Movement : Photon.MonoBehaviour {

<<<<<<< HEAD
	public float speed;
	public float jumpSpeed;
	public float gravity;

    public static GameObject LocalPlayerInstance;





    private Rigidbody rb;
    public Vector3 moveDirection;
    private bool candoublejump;
	 
=======
	public float speed;     //Määrää pelaajan nopeuden
	public float jumpSpeed;     //Määrää pelaajan hypyn korkeuden
	public float gravity;       //Määrää painovoiman suuruuden

    private Rigidbody rb;
    public Vector3 moveDirection;
    private bool candoublejump;     //Tarkistaa, pystyykö pelaaja tekemään tuplahypyn


    //Pitäisi tarkistaa moninpelissä, onko tämä hahmo tämän pelaajan. Jos ei => hahmon liikuttaminen ei ole mahdollista. Ei toimi tällä hetkellä
>>>>>>> edca8fe4a93bcec7e639e47f95a7f908da01d4fd
    void Awake()
    {
        if(!photonView.isMine)
        {
            enabled = false;
        }
        DontDestroyOnLoad(this.gameObject);
    }

<<<<<<< HEAD

=======
>>>>>>> edca8fe4a93bcec7e639e47f95a7f908da01d4fd
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
		

		
    void Update()
	{
<<<<<<< HEAD
		if (photonView.isMine) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * speed, rb.velocity.y, Input.GetAxis ("Vertical") * speed);
			moveDirection = transform.TransformDirection (moveDirection);
=======
        if (photonView.isMine)
            {
            //Liikkuminen
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);
            moveDirection = transform.TransformDirection(moveDirection);
>>>>>>> edca8fe4a93bcec7e639e47f95a7f908da01d4fd

            //Hyppiminen
            if (Input.GetKeyDown(KeyCode.Space))
                if (isGrounded()) {
                    moveDirection.y = jumpSpeed;
                    candoublejump = true;
                } else {
                    if (candoublejump) {
                        moveDirection.y = jumpSpeed;
                        candoublejump = false;
                    }

                }

            moveDirection.y -= gravity * Time.deltaTime;
            rb.velocity = moveDirection;
        }
		}
	}

	//Tarkistaa, koskettaako pelaaja maata
    bool isGrounded ()
    {
        Vector3 position = transform.position;
        position.y = GetComponent<Collider>().bounds.min.y + 0.1f;
        float length = 0.5f;
        Debug.DrawRay(position, Vector3.down * length);
        bool grounded = Physics.Raycast(position, Vector3.down, length, LayerMask.GetMask("Default"));
        return grounded;
    }
}
