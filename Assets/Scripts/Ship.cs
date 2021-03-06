﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {

	public int crewCap = 300;
	public int crewCount;
	public float speed = 5;

	public Text crewText;
	public Text speedText;

	public GameObject player;

	public List<GameObject> warps = new List<GameObject>();

	// Use this for initialization
	void Start () {
		crewCount = crewCap;
	}


	void Movement()
	{
		if (Input.GetKey (KeyCode.D)) {
			player.transform.Translate (new Vector3 (0, 0, speed * 0.005f));
		}

		if (Input.GetKey (KeyCode.A)) {
			player.transform.Translate (new Vector3 (0, 0, speed * -0.005f)); 
		}

		if (Input.GetKey (KeyCode.S)) {
			player.transform.Translate (new Vector3 (speed * 0.005f, 0, 0));
		}

		if (Input.GetKey (KeyCode.W)) {
			player.transform.Translate (new Vector3 (speed * -0.005f, 0, 0));
		}

		Vector3 v = Vector3.zero;
		gameObject.transform.position = Vector3.SmoothDamp (gameObject.transform.position, new Vector3 (player.transform.position.x, player.transform.position.y, -10), ref v, 0.15f);
	}

	// Update is called once per frame
	void Update () {
		crewText.text = "Crew: " + crewCount;
		speed = crewCount/60;

		speedText.text = "Speed: " + speed;

		if (Input.GetKey (KeyCode.Q))
			crewCount--;

		if (Input.GetKey (KeyCode.E))
			crewCount++;

		if (crewCount > crewCap)
			crewCount = crewCap;

		if (crewCount < 0)
			crewCount = 0;

		Movement ();
	}
}
