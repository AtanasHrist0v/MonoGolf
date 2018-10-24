using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> prefabList = new List<GameObject>();
    float Pos = 7F;
    void Start () {
        
        for (int i = 0; i < 2; i++)
        {
            Instantiate(prefabList[Random.Range(0, 2)], new Vector3(2.5F, 0.5F, Pos + 15 * i), Quaternion.identity);
        }
        Instantiate(prefabList[2], new Vector3(2.5F, 0.5F, Pos + 15 * 2), Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
