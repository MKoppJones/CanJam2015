using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	public Ship playerShip;
	public Log gameLog;
	public float timer = 0.2f;
	float counter = 0.0f;
	
	void OnTriggerEnter(Collider col)
	{
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

		switch (col.tag) {
		case "Aura":
			System.Random rnd = new System.Random();
			playerShip.crewCount -= rnd.Next (0,15);
			gameLog.inAura = true;
			gameLog.OutputInAura();
			break;
		}
	}

	void OnTriggerStay(Collider col)
	{
		switch (col.tag) {
		case "Aura":
			counter += Time.deltaTime;
			if (counter >= timer)
			{
			System.Random rnd = new System.Random();
			playerShip.crewCount -= rnd.Next (0,25);
			gameLog.inAura = true;
			gameLog.OutputInAura();
				counter = 0;
			}
			break;
		}
	}

	void OnTriggerExit()
	{
		gameLog.inAura = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
