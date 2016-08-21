using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WebServiceAgent : MonoBehaviour {
	[Tooltip("A string to be sent to the server")]
	public string message = "Hello I sent this from Unity!";

	//Might need to change these to setting from file, for easy config
	string URL = "localhost";
	int Port = 25331;
    WWW con;
	void Start () {
		//Initialize the URL for communicating with the server
		string connectionString = "http://" + URL + ":" + Port + "/api/message";

		//We use simple GET method on Http Protocol, so we utilize the WWW class of mono to handle things
		con = new WWW(connectionString + "?msg=" + System.Uri.EscapeDataString(message));

		//TODO might need to change to POST method with proper data model if we send more complicated data.
	}

    public void Connect()
    {
        StartCoroutine(_Connect());
    }

    IEnumerator _Connect()
    {
		Debug.Log ("Sending message 'Hello' to the server...");
        
        yield return con;

		if (con.error != null) {
			Debug.Log ("Connection error! : " + con.error);
			yield break;
		}

		string response = con.text;
		Debug.Log ("The response from server: " + response);
    }
}

