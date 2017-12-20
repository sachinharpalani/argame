using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	public Image fillImg1;
	public Image fillImg2;
	Image fillImg;
	float timeAmt = 20;
	float time;
	public Button power;
	public Text timeText;
	bool clicked = false;

	// Use this for initialization
	void Start () {
		fillImg2.enabled = false;
		fillImg = fillImg1;
		time = timeAmt;

		power.onClick.AddListener (addFive);
	}
	void addFive (){


		Debug.Log ("power added");
		if (clicked == false && time < 25) {
			time += 5;
			clicked = true;

		}

	}



	// Update is called once per frame
	void Update () {
		if (time < 10) {
			fillImg1.enabled = false;
			fillImg2.enabled = true;
			fillImg = fillImg2;
			timeText.color = Color.red;
		}

		if (time > 10) {
			fillImg2.enabled = false;
			fillImg1.enabled = true;
			fillImg = fillImg1;
			timeText.color = Color.white;
		}

		if(time > 0)
		{
			time -= Time.deltaTime;
			fillImg.fillAmount =  time / timeAmt;
			timeText.text = "Time :\n"+ time.ToString("F");


		}


		
	}
}
