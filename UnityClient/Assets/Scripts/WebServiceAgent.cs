using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class WebServiceAgent : MonoBehaviour {
	[HideInInspector]
	public static WebServiceAgent instance;

	[Tooltip("A string to be sent to the server")]
	public string message = "Hello I sent this from Unity!";

	//Might need to change these to setting from file, for easy config
	string URL = "localhost";
	int Port = 25331;
	UnityWebRequest  con;
	void Start () {
		if (instance == null) {
			instance = this;
			this.Initialize ();
		} else
			Destroy (this);
	}

	void Initialize()
	{
		//Initialize the URL for communicating with the server
		string connectionString = "http://" + URL + ":" + Port + "/api/message";

		//We use simple GET method on Http Protocol, so we utilize the WWW class of mono to handle things
//		con = new WWW(connectionString + "?msg=" + System.Uri.EscapeDataString(message));

		//TODO might need to change to POST method with proper data model if we send more complicated data.
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("Content-Type", "application/json");
		headers.Add("Content-Length", message.Length.ToString());

		WWWForm form = new WWWForm();
		form.AddField("msg", message);

		con = UnityWebRequest.Post(connectionString, form);
	}


	/// <summary>
	/// Start communicating with the server
	/// </summary>
    public void Connect()
    {
        StartCoroutine(Connect_Proceed());
    }

    IEnumerator Connect_Proceed()
    {
		Debug.Log ("Sending message 'Hello' to the server...");
        
		yield return con.Send();

		if (con.error != null) {
			Debug.Log ("Connection error! : " + con.error);
			yield break;
		}

		string response = con.downloadHandler.text;
		Debug.Log ("The response from server: " + response);
    }
}

