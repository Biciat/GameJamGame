using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ToBattle : MonoBehaviour {

    public SlotSelector player1;
    public SlotSelector player2;


    Animation myDance;
    AudioSource mySound;
    static int NEXT_LEVEL = 1;
	// Use this for initialization
	void Start () {
        myDance = GetComponent<Animation>();
        mySound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoToBattle() {
        int charP1 = player1.navPos;
        int charP2 = player2.navPos;


        PlayerPrefs.SetInt("p1",charP1);
        PlayerPrefs.SetInt("p2", charP2);
        mySound.Play();
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(.9f);
        Application.LoadLevel(NEXT_LEVEL);

    }

    internal void doDance()
    {
        myDance.Play();
    }
}
