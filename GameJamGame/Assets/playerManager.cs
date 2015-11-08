using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour {
	//Public
	public GameObject Player1, Player2;
    // Use this for initialization
    private int p1Id;
    private int p2Id;

    public GameObject toasterPrefab;
    public GameObject beaterPrefab;

    Vector3 p1Pos, p2Pos;
    Quaternion p1Rot, p2Rot;

    public LifeBar lifePlayer1, lifePlayer2;

    void Awake()
    {

        p1Id = PlayerPrefs.GetInt("p1");
        p2Id = PlayerPrefs.GetInt("p2");

        p1Pos = Player1.transform.position;
        p2Pos = Player2.transform.position;

        p1Rot = Player1.transform.rotation;
        p2Rot = Player2.transform.rotation;
    
        
    }

        void Start () {

        if (p1Id == 1) {
            Player1 = (GameObject)Instantiate(beaterPrefab, p1Pos, p1Rot);
        }
        if (p2Id == 1)
        {
            Player2 = (GameObject)Instantiate(beaterPrefab, p2Pos, p2Rot);
        }

        if (p1Id == 2)
        {
            Player1 = (GameObject)Instantiate(toasterPrefab, p1Pos, p1Rot);
        }
        if (p2Id == 2)
        {
            Player2 = (GameObject)Instantiate(toasterPrefab, p2Pos, p2Rot);
        }

        Player1.GetComponent<AliveObjectStats>().myLife = lifePlayer1;
        Player2.GetComponent<AliveObjectStats>().myLife = lifePlayer2;

        Player1.tag = "Player1";
		Player2.tag = "Player2";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
