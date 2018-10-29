using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		Debug.Log("Collision Exists");
		if(col.gameObject.name == "Trigger") 
		{
			Debug.Log("Collision Detected");
		}
	}
}
