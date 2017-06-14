using UnityEngine;
using System.Collections;

public class Movement : Photon.MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	public float gravity;
<<<<<<< HEAD
    public static GameObject LocalPlayerInstance;
=======
	public static GameObject LocalPlayerInstance;

>>>>>>> 871ab4894cee7e33eca6b74a2e1388d4c3d9e0e3

    private Rigidbody rb;
    public Vector3 moveDirection;
    private bool candoublejump;

<<<<<<< HEAD
    void Awake()
    {
        if(photonView.isMine)
        {
            Movement.LocalPlayerInstance = this.gameObject;
        }
        DontDestroyOnLoad(this.gameObject);
    }

=======
	void Awake(){
		if (photonView.isMine) {
			Movement.LocalPlayerInstance = this.gameObject;
	
		}
		DontDestroyOnLoad (this.gameObject);
	}
>>>>>>> 871ab4894cee7e33eca6b74a2e1388d4c3d9e0e3
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	
		}
		

		
    void Update()
	{
		if (photonView.isMine == false && PhotonNetwork.connected == true) {
			return;}
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * speed, rb.velocity.y, Input.GetAxis ("Vertical") * speed);
			moveDirection = transform.TransformDirection (moveDirection);

			if (Input.GetKeyDown (KeyCode.Space))
			if (isGrounded ()) {
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
