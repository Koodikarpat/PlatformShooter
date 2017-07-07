#pragma strict

function Start () {
	print("Width = ");
	print(Vector3.Distance(GameObject.Find("Base/Width").transform.position, GameObject.Find("Base").transform.position));
	print("Height = ");
	print(Vector3.Distance(GameObject.Find("Base/Height").transform.position, GameObject.Find("Base").transform.position));
	print("Depth = ");
	print(Vector3.Distance(GameObject.Find("Base/Depth").transform.position, GameObject.Find("Base").transform.position));
	print("Distance = ");
	print(Vector3.Distance(GameObject.Find("DistanceCounter").transform.position, GameObject.Find("DistanceCounter/Target").transform.position));

}

function Update () {
	
}
