using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkAnswer : MonoBehaviour {

	public InputField input;
	public Text answer;
	public Button submit;

	public void checkAns()
	{
		Debug.Log (input.text);
		answer.text = input.text;	
	}


	// Use this for initialization
	void Start () {

		submit.onClick.AddListener (checkAns);
		
	}


	// Update is called once per frame
	void Update () {
		
	}
}
