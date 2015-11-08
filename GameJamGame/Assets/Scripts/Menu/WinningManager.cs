using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinningManager : MonoBehaviour {

    int playerwin = -1;
    int charwin = -1;
    int charlose = -1;
    public Text message;

    void Awake() {
        playerwin = PlayerPrefs.GetInt("winer");
        charwin = PlayerPrefs.GetInt("charwin");
        charlose = PlayerPrefs.GetInt("charlose"); 
    }

	// Use this for initialization
	void Start () {
        if (playerwin == 0 || charwin == 0 || charlose == 0)
        {
            message.text = "No Contest";

        }
        else {
            message.text = getPlayerText(playerwin) + " " + getCharacterText(charwin);
        }
     
	}

    private string getPlayerText(int i) {
        if (i == 1) return "Player One!";
        if (i == 2) return "Player Two!";
        return "";
    }

    private string getCharacterText(int i) {
        if (i == 1) return "The Brave Beater!";

        if (i == 2) return "The Trusty Toaster!";
        return "";
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
