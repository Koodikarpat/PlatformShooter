using UnityEngine;
using System.Collections;

//Hoitaa liikkumisen ja hyppimisen
public class Movement : Photon.MonoBehaviour {
	 
	public float speed;     //Määrää pelaajan nopeuden
	public float jumpSpeed;     //Määrää pelaajan hypyn korkeuden
	public float gravity;   //Määrää painovoiman suuruuden

    private GameObject ladder;
    private Rigidbody rb;
    public Vector3 moveDirection;
    private bool candoublejump;     //Tarkistaa, pystyykö pelaaja tekemään tuplahypyn
    public bool canClimb;           //Tarkistaa, pystyykö pelaaja kiipeämään


    //Pitäisi tarkistaa moninpelissä, onko tämä hahmo tämän pelaajan. Jos ei => hahmon liikuttaminen ei ole mahdollista. Ei toimi tällä hetkellä
    void Awake()
    {
        if(!photonView.isMine)
        {
            enabled = false;
        }
        DontDestroyOnLoad(this.gameObject);
    }

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
        ladder = GameObject.Find("Ladder");
	}

    //Tarkistavat, koskettaako pelaaja tikkaita
    void OnTriggerEnter (Collider collider)
    {
        if(collider.gameObject == ladder)
        {
            canClimb = true;
            rb.useGravity = false;
        }
    }

    void OnTriggerExit (Collider collider)
    {
        if (collider.gameObject == ladder)
        {
            canClimb = false;
            rb.useGravity = true;
        }
    }
		

		
    void Update()
    {
        if (canClimb)
        {
            //Tikkailla liikkuminen
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 up = new Vector3(0, 1, 0);
                transform.Translate(up * Time.deltaTime * speed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Vector3 down = new Vector3(0, -1, 0);
                transform.Translate(down * Time.deltaTime * speed);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Vector3 left = new Vector3(-1, 0, 0);
                transform.Translate(left * Time.deltaTime * speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Vector3 right = new Vector3(1, 0, 0);
                transform.Translate(right * Time.deltaTime * speed);
            }
            else
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        else
        {
            //Normaali liikkuminen
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);
            moveDirection = transform.TransformDirection(moveDirection);

            //Hyppiminen
            if (Input.GetKeyDown(KeyCode.Space))
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
            rb.velocity = moveDirection;
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
