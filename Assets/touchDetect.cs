using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class touchDetect : MonoBehaviour {
	public GameObject price;
	private string prev = "";
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{


			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (prev != "" && prev != hit.transform.name) 
				{
					var prevObj = GameObject.Find (prev);
					prevObj.transform.localScale = prevObj.transform.localScale / 2.0F;
				}

				prev = hit.transform.name;
				Debug.Log(hit.transform.name);
				var origScale = hit.transform.localScale;
				//Debug.Log (origScale);
				var newScale = hit.transform.localScale * 2.0F;
				//Debug.Log (newScale);

				hit.transform.localScale = newScale;

				price.GetComponent<Text> ().text = "Price: 50";

				if (prev != hit.transform.name) {
					
					hit.transform.localScale = newScale;
					price.GetComponent<Text> ().text = "Price: 50";
				}

				if (hit.transform.name == "IceCream") 
				{
					StartCoroutine(GetText());
				}
					
			}
		}

	}

	IEnumerator GetText() {
		UnityWebRequest www = UnityWebRequest.Get("http://app.mindseed.in:9080/books");
		yield return www.SendWebRequest();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			// Show results as text
			Debug.Log(www.downloadHandler.text);

			// Or retrieve results as binary data
			//byte[] results = www.downloadHandler.data;
		}
	}
}
