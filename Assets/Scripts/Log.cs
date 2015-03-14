using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Log : MonoBehaviour {

	public Text logText;
	public List<string> flavour = new List<string>();
	
	// Use this for initialization
	void Start () {
		
	}

	public void Output()
	{
		logText.text = "Nothin' to report Cap'n";
	}

	public void Output(int count)
	{
		System.Random rnd = new System.Random ();
		logText.text = "You lost " + count + " crew member(s) " + flavour[rnd.Next(flavour.Count)];
	}
}
