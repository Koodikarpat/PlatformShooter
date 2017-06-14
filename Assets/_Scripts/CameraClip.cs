using UnityEngine;
using System.Collections;

class CameraClip : MonoBehaviour {

	private float minimumDistance;
	private float maximumDistance;
    public float speedToFixClipping;
	public bool scoped = false;
    private Vector3 normalDistance;
	public Texture2D scope;


	public void DefinePosition()
	{
		transform.localPosition = normalDistance;
		Vector3 position = transform.position;
		Vector3 scopePosition = transform.parent.position + Vector3.up;
		float length = Vector3.Distance (position, scopePosition);
		Debug.DrawRay(position, scopePosition - position, Color.green, 1f);
		RaycastHit hit;
		bool obstructed = Physics.Raycast(scopePosition, position - scopePosition, out hit, length);
	}
	void Start()
	{
		minimumDistance = transform.localPosition.z;
		maximumDistance = transform.localPosition.z;
		normalDistance = transform.localPosition;
	}
    void Update ()
    {
		float currentDistance = normalDistance.z;
		if (Input.GetKeyDown (KeyCode.Mouse1) && !scoped) {
			currentDistance = 0;
			scoped = true;

		

		} else if( Input.GetKeyDown (KeyCode.Mouse1) && scoped) {
			currentDistance = maximumDistance;
			scoped = false;

		 
		}
			
		transform.localPosition = normalDistance;
        Vector3 position = transform.position;
        Vector3 scopePosition = transform.parent.position + Vector3.up;
        float length = Vector3.Distance (position, scopePosition);
       
        RaycastHit hit;
        bool obstructed = Physics.Raycast(scopePosition, position - scopePosition, out hit, length);
		  
		
        if (obstructed)
        {
            transform.position = hit.point;
        }
       
        normalDistance = new Vector3(transform.localPosition.x, transform.localPosition.y, currentDistance);
    }

}

