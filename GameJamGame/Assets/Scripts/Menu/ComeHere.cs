using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComeHere : MonoBehaviour {

    public PlayerSelect player;
    public SlotSelector selector;
    public int pos;
    RectTransform myPosition;
	// Use this for initialization
	void Start () {
        myPosition = this.GetComponent<RectTransform>(); 

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void getOverHere() {
        player.moveTo(myPosition.position.x, myPosition.position.y);
        selector.setNavPosition(pos);
    }




}
