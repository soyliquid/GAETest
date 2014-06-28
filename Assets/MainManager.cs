using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {

	public string postStatus = "Push to Post";
	public string getStatus = "Push to Get";

	void OnGUI() {
		if(GUI.Button(new Rect(0f, 0f, 80f, 30f), "Post")) {
			string data = Random.Range(-100, 100).ToString("000");
			postStatus = "Posting... value=" + data;
			StartCoroutine(DBModule.DoPost("ID", data, PostDone));
		}
		if(GUI.Button(new Rect(0f, 30f, 80f, 30f), "Get")) {
			getStatus = "Getting...";
			StartCoroutine(DBModule.DoGet("ID", GetDone));
		}
		GUI.Label(new Rect(80f, 0f, 80f, 180f), postStatus);
		GUI.Label(new Rect(80f, 30f, 80f, 180f), getStatus);
		GUI.Label(new Rect(0f, 60f, 80f, 180f), DBModule.Result);
	}
	
	void PostDone() {
		postStatus = "Post Done.";
	}

	void GetDone() {
		getStatus = "Get Done.";
	}

}
