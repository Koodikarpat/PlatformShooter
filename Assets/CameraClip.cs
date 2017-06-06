using UnityEngine;
using System.Collections;

public class CameraClip : MonoBehaviour {

    public float minimumDistance;
    public float maximumDistance;
    public float speedToFixClipping;

    private Vector3 clipDistance;
    private Vector3 normalDistance;
    

    void Update ()
    {
        transform.localPosition = normalDistance;
        Vector3 position = transform.position;
        Vector3 scopePosition = transform.parent.position + Vector3.up;
        float length = Vector3.Distance (position, scopePosition);
        Debug.DrawRay(position, scopePosition - position, Color.green, 1f);
        RaycastHit hit;
        bool obstructed = Physics.Raycast(scopePosition, position - scopePosition, out hit, length);
        
        if (obstructed)
        {
            transform.position = hit.point;
        }
       



        clipDistance = new Vector3(transform.localPosition.x, transform.localPosition.y, minimumDistance);
        normalDistance = new Vector3(transform.localPosition.x, transform.localPosition.y, maximumDistance);
    }

}
