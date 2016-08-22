using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class WebServiceAgent : MonoBehaviour {
	[HideInInspector]
	public static WebServiceAgent instance;

	[Tooltip("A string to be sent to the server")]
	public string message = "Hello I sent this from Unity!";

	//Might need to change these to setting from file, for easy config
	string URL = "localhost";
	int Port = 25331;

	string connectionString;
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
		connectionString = "http://" + URL + ":" + Port + "/api/message";
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
		
		//We use POST method with proper data model to support more complicated data communication in the future.
		string data = JsonUtility.ToJson(new DataModel(message));
		Debug.Log ("Sending message to the server... : " + data);
		con = new UnityWebRequest(connectionString, "POST");
		byte[] body = Encoding.UTF8.GetBytes(data);
		con.uploadHandler = new UploadHandlerRaw(body);
		con.downloadHandler = new DownloadHandlerBuffer();
		con.SetRequestHeader("Content-Type", "application/json");
		//Start communication
		yield return con.Send();

		if (con.error != null) {
			Debug.Log ("Connection error! : " + con.error);
			yield break;
		}

		string response = con.downloadHandler.text;
		Debug.Log ("The response from server: " + response);

		con.Dispose ();
    }

    
	//================= Data Model ================
	[System.Serializable]
	public class DataModel
	{
		public string msg;

		public DataModel(string msg)
		{
			this.msg = msg;
		}
	}
}

