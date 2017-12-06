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
					StartCoroutine (GetText ());
					//StartCoroutine(Upload());
				}
					
			}
		}

	}

	IEnumerator GetText() {
		UnityWebRequest www = UnityWebRequest.Get("https://reqres.in/api/users?page=2");
		yield return www.SendWebRequest();	

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			// Show results as text
			string json1 = www.downloadHandler.text;
			JsonOutput op1 = JsonUtility.FromJson<JsonOutput> (json1);
			

			Debug.Log (op1.data[0].first_name);

			// Or retrieve results as binary data
			//byte[] results = www.downloadHandler.data;
			//Debug.Log(results [0]);
		}
	}

	IEnumerator Upload() {
		WWWForm form = new WWWForm();
		form.AddField("name", "sachin");

		UnityWebRequest www = UnityWebRequest.Post("https://reqres.in/api/users", form);
		yield return www.SendWebRequest();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			Debug.Log("Form upload complete!");
			Debug.Log (www.downloadHandler.text);
		}
	}
	[System.Serializable]
	public class data
	{
		public string id;
		public string first_name;
		public string last_name;
		public string avatar;
	}
		
	[System.Serializable]
	public class JsonOutput
	{
		public string  page;
		public string  per_page;
		public string  total;
		public string  total_pages;
		public List<data> data;
	}
}
