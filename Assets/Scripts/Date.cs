using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Date : MonoBehaviour {

	public Text DateText;
	public Ship playerShip;
	public Log gameLog;
	public float timer = 0.2f;

	List<string> Day = new List<string>();
	List<string> Month = new List<string>();
	int day = 1;
	int year = 1600;
	int i = 0;
	int j = 0;
	string daysuffix = "st";
	float counter = 0;
	int[] daysInMonth = new int[12] {31,28,31,30,31,30,31,31,30,31,30,31};

	// Use this for initialization
	void Start () {
		Day.Add ("Monday");
		Day.Add ("Tuesday");
		Day.Add ("Wednesday");
		Day.Add ("Thursday");
		Day.Add ("Friday");
		Day.Add ("Saturday");
		Day.Add ("Sunday");

		Month.Add ("January");
		Month.Add ("February");
		Month.Add ("March");
		Month.Add ("April");
		Month.Add ("May");
		Month.Add ("June");
		Month.Add ("July");
		Month.Add ("August");
		Month.Add ("September");
		Month.Add ("October");
		Month.Add ("November");
		Month.Add ("December");
	}
	
	// Update is called once per frame
	void Update () {
		switch (day) {
		case 1:
			daysuffix = "st";
			break;
		case 2:
			daysuffix = "nd";
			break;
		case 3:
			daysuffix = "rd";
			break;
		default:
			daysuffix = "th";
			break;
		}

		if (i > 6)
		{
			i = 0;

			System.Random rnd = new System.Random();
			int r = rnd.Next (0,10);
			if (r == 0)
			{
				gameLog.Output();
			}
			else
			{
				playerShip.crewCount -= r;
				gameLog.Output(r);
			}

		}

		if (day > daysInMonth[j])
		{
			day = 1;
			j++;
		}

		if (j > 11)
		{
			j = 0;
			year++;
		}

		DateText.text = Day [i] + " " + day + daysuffix + " " + Month [j] + " " + year;
		counter += Time.deltaTime;
		if (counter >= timer)
		{
			day++;
			i++;
			counter = 0;
		}
	}
}
