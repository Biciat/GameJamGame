using UnityEngine;
using System.Collections;

public class ComeHere : MonoBehaviour {

    public PlayerSelect player;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void getOverHere() {
        player.moveTo(this.transform.position.x, this.transform.position.y);

    }


}
