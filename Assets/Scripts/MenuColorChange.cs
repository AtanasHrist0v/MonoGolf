using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuColorChange : MonoBehaviour 
{

	void Start () 
	{
		int i = Random.Range (1, 7);
		Debug.Log = "";
		switch (i) 
		{
		case 1:
			Camera.current.backgroundColor = Color(63,85,173);
			break;
		case 2:
			Camera.current.backgroundColor = Color(63,173,110);
			break;
		case 3:
			Camera.current.backgroundColor = Color(63,173,63);
			break;
		case 4:
			Camera.current.backgroundColor = Color(191,188,28);
			break;
		case 5:
			Camera.current.backgroundColor = Color(200,54,45);
			break;
		case 6:
			GetComponent<UnityEngine.UI.Image> ().color = Color(231,95,116);
			break;
		case 7:
			GetComponent<UnityEngine.UI.Image> ().color = Color(170,44,190);
			break;
		}
	}

}
