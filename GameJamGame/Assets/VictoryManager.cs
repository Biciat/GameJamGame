using UnityEngine;
using System.Collections;

public class VictoryManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void Victory(int playerId, int winerCharid, int loserCharid) {
        PlayerPrefs.SetInt("winer", playerId);
        PlayerPrefs.SetInt("charwin", winerCharid);
        PlayerPrefs.SetInt("charlose", loserCharid);
        Application.LoadLevel(2);
    }


}
