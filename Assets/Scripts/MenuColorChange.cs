using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuColorChange : MonoBehaviour 
{
	public Camera cam;

	void Start () 
	{
		int i = Random.Range (1, 7);
		Debug.Log ("i = " + i);

		Color c1 = new Color32 (63,85,173, 0);
		Color c2 = new Color32 (63,173,110, 0);
		Color c3 = new Color32 (63,173,63, 0);
		Color c4 = new Color32 (191,188,28, 0);
		Color c5 = new Color32 (200,54,45, 0);
		Color c6 = new Color32 (231,95,116, 0);
		Color c7 = new Color32 (170,44,190, 0);

		switch (i)
		{
		case 1:
			cam.backgroundColor = c1;
			break;
		case 2:
			cam.backgroundColor = c2;
			//Canvas.FindObjectOfType<Button>()>().image = Color.black;
			break;
		case 3:
			cam.backgroundColor = c3;
			break;
		case 4:
			cam.backgroundColor = c4;
			break;
		case 5:
			cam.backgroundColor = c5;
			break;
		case 6:
			cam.backgroundColor = c6;
			break;
		case 7:
			cam.backgroundColor = c7;
			break;
		}
	}

}
