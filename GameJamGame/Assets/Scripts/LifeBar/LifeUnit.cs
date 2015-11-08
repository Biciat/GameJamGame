using UnityEngine;
using System.Collections;

//Only handles the fadeout of a heart
public class LifeUnit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void vanish() {
        this.transform.localScale = new Vector3 (0,0,0);
       
    }

    public void imTheLastOne() { }


}
