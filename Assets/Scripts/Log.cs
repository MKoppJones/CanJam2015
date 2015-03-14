using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Log : MonoBehaviour {

	public Text logText;
	public List<string> flavour = new List<string>();
	public bool inAura = false;

	// Use this for initialization
	void Start () {
		
	}

	public void Output()
	{
		if (!inAura)
		{
			logText.text = "Nothin' to report Cap'n";
		}
	}

	public void Output(int count)
	{
		if (!inAura)
		{
			System.Random rnd = new System.Random ();
			logText.text = "You lost " + count + " crew member(s) " + flavour [rnd.Next (flavour.Count)];
		}
	}

	public void OutputInAura()
	{
		logText.text = "You are losing crew as you are too close to that other ship";
	}
}
