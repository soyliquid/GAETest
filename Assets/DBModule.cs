using UnityEngine;
using System.Collections;
using System;

public class DBModule
{

	public static string ServerURL = "http://hogehoge-application.appspot.com/simple_db";
	public static string Result;

	public static IEnumerator DoPost(string key, string data, Action callback)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("name", key);
		form.AddField ("data", data);
		WWW www = new WWW (ServerURL, form);
		yield return www;
		if (!string.IsNullOrEmpty (www.error)) {
			Debug.LogError (www.error);
			yield break;
		}
		Debug.Log("DoPost Done.");
		if(callback != null) {
			callback.Invoke();
		}
	}
	
	public static IEnumerator DoGet(string key, Action callback)
	{
		WWW www = new WWW (ServerURL+"?name="+key);
		yield return www;
		if (!string.IsNullOrEmpty (www.error)) {
			Debug.LogError (www.error);
			yield break;
		}
  		Result = www.text;
		Debug.Log("DoGet Done.");
		if(callback != null) {
			callback.Invoke();
		}
	}

}
