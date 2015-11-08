using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour {
	//Public
	public GameObject Player1, Player2;
	// Use this for initialization
	void Start () {
		Player1.tag = "Player1";
		Player2.tag = "Player2";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
