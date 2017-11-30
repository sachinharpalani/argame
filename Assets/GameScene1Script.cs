using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene1Script : MonoBehaviour {

	public Button teamGames;
	public Button individualGame;

	// Use this for initialization
	void Start () {

		teamGames.onClick.AddListener (ChangeScene1);
		individualGame.onClick.AddListener (ChangeScene2);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeScene1(){

		Debug.Log ("Btn1 clicked");

		SceneManager.LoadScene ("GameScene2");
	}

	void ChangeScene2(){

		Debug.Log ("Btn2 clicked");	
		
		SceneManager.LoadScene ("GameScene2");
	}
}
