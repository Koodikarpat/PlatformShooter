using UnityEngine;
using System.Collections;

public class Movement : Photon.MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	public float gravity;

    private Rigidbody rb;
    public Vector3 moveDirection;
    private bool candoublejump;

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
