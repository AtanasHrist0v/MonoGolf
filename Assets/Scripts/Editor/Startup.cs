using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[InitializeOnLoad]
public class Startup : MonoBehaviour {
	static Startup()
	{
		int width = 0, height = 0, scalew = 0, scaleh = 0;

		Debug.Log("Up and running");

		width = Screen.width;
		height = Screen.height;
		Debug.Log(width);
		Debug.Log(height);

		scalew = width / 9;
		Debug.Log(scalew);
	}
}
