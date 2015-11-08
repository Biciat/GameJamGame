using UnityEngine;
using System.Collections;

public class ToBattle : MonoBehaviour {

    public SlotSelector player1;
    public SlotSelector player2;

    static int NEXT_LEVEL = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoToBattle() {
        int charP1 = player1.navPos;
        int charP2 = player2.navPos;

        PlayerPrefs.SetInt("p1",charP1);
        PlayerPrefs.SetInt("p2", charP2);

        Application.LoadLevel(NEXT_LEVEL);

    }


}
