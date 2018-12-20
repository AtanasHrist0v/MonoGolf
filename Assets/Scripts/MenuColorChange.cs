using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuColorChange : MonoBehaviour 
{
	public Camera cam;
	public Button button1, button2, button3;
	void Start ()
	{
		int i = 2;//Random.Range (1, 7);
		Debug.Log ("i = " + i);
		switch (i)
		{
		case 1:
			cam.backgroundColor = new Color32 (63,85,173, 0);
			button1.image.color = new Color32(6,115,255,255);
			button2.image.color = new Color32(6,115,255,255);
			button3.image.color = new Color32(6,115,255,255);
			break;
		case 2:
			cam.backgroundColor = new Color32 (63, 173, 110, 0);
			button1.image.color = new Color32();
			button2.image.color = new Color32();
			button3.image.color = new Color32();
			break;
		case 3:
			cam.backgroundColor = new Color32 (63,173,63, 0);
			button1.image.color = new Color32();
			button2.image.color = new Color32();
			button3.image.color = new Color32();
			break;
		case 4:
			cam.backgroundColor = new Color32 (191,188,28, 0);
			button1.image.color = new Color32();
			button2.image.color = new Color32();
			button3.image.color = new Color32();
			break;
		case 5:
			cam.backgroundColor = new Color32 (200,54,45, 0);
			button1.image.color = new Color32();
			button2.image.color = new Color32();
			button3.image.color = new Color32();
			break;
		case 6:
			cam.backgroundColor = new Color32 (231,95,116, 0);
			button1.image.color = new Color32();
			button2.image.color = new Color32();
			button3.image.color = new Color32();
			break;
		case 7:
			cam.backgroundColor = new Color32 (170,44,190, 0);
			button1.image.color = new Color32();
			button2.image.color = new Color32();
			button3.image.color = new Color32();
			break;
		}
	}
}
