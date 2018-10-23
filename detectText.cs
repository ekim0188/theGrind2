using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//displayed on console to test linking scrpt and gameObj
		//Debug.Log ("This worked");
		gameObject.GetComponent<InputField>().onEndEdit.AddListener(displayText);
	}

	private void displayText(string textInField)
	{
		print (textInField);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
