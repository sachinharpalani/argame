using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene2Script : MonoBehaviour {

	public Button task1;
	public Button task2;
	public Button task3;

	
	// Use this for initialization
	void Start () {

		task1.onClick.AddListener (OpenCamScene);
		//task2.onClick.AddListener (OpenCamScene);
		//task3.onClick.AddListener (OpenCamScene);

		}

	void OpenCamScene()
	{
		Debug.Log ("Task1 clicked");
		SceneManager.LoadScene("GameScene3");	
	}
}
