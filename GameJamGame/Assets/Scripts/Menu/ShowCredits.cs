using UnityEngine;
using System.Collections;

public class ShowCredits : MonoBehaviour {

    public GameObject mCredits;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void show() {
        mCredits.SetActive(true);

    }

    public void hide() {
        mCredits.SetActive(false);
    }

}
