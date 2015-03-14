using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("WOOOO");
		switch (col.name) {
		case "Warperbottom":
			transform.position = new Vector3(transform.position.x, 4.5f, 0);
			break;
		case "Warperright":
			transform.position = new Vector3(-8.75f, transform.position.y, 0);
			break;
		case "Warpertop":
			transform.position = new Vector3(transform.position.x, -4.5f, 0);
			break;
		case "Warperleft":
			transform.position = new Vector3(8.75f, transform.position.y, 0);
			break;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
