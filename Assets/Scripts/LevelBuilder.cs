using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> prefabList = new List<GameObject>();
    float Pos = 7F;
    public byte shotsLeft;
    int randNumber;
    void Start () {
        
        for (int i = 0; i < 2; i++)
        {
            randNumber = Random.Range(0, 2);
            Instantiate(prefabList[randNumber], new Vector3(2.5F, 0.5F, Pos + 15 * i), Quaternion.identity);
            switch (randNumber)
            {
                case 0: shotsLeft += 3;
                    break;
                case 1: shotsLeft += 2;
                    break;
            }
            shotsLeft += 2;
        }
        Instantiate(prefabList[2], new Vector3(2.5F, 0.5F, Pos + 15 * 2), Quaternion.identity);
    }

    void Update() { }
}
