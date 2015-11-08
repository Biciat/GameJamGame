using UnityEngine;
using System.Collections;

public class CharacterSpawnManager : MonoBehaviour {

    void Awake() {

        int p1 = PlayerPrefs.GetInt("p1");
        int p2 = PlayerPrefs.GetInt("p2");
        print(p1 + " vs " + p2);


    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
