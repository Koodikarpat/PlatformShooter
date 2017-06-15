using UnityEngine;
using System.Collections;

//Hoitaa, että kamera ei mene lattian tai seinien läpi
class CameraClip : MonoBehaviour {

	private float minimumDistance;
	private float maximumDistance;
    public float speedToFixClipping;        //Aika, jossa kameran paikka muuttuu
	public bool scoped = false;
    private Vector3 normalDistance;
	public Texture2D scope;

    //Tarkistaa kameran nykyisen paikan
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
        
        //Mahdollistaa kameran zoomauksen
		if (Input.GetKeyDown (KeyCode.Mouse1) && !scoped)
        {
			currentDistance = 0;
			scoped = true;
        }
        else if( Input.GetKeyDown (KeyCode.Mouse1) && scoped)
        {
			currentDistance = maximumDistance;
			scoped = false;
        }
		
        //Muuttaa kameran paikan lähemmäksi pelaajaa, jos kameran ja pelaajan väliin tulee esim. lattia tai seinä. Siirtää myös kameran takaisin alkuperäiselle paikalleen, kun este häviää	
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

