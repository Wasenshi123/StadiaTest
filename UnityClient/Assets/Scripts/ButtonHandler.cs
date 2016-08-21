using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {

	public void OnClick()
	{
		Debug.Log ("The button '" + name + "' has been clicked.");
	}
}
