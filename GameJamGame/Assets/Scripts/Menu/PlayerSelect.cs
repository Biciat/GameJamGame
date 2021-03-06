﻿using UnityEngine;
using System.Collections;

public class PlayerSelect : MonoBehaviour {

    float basex;
    float basey;

    Vector3 startPos;
    Vector3 endPos;

    bool moving = false;
    float speed = 0.2f;
    float travelTime = 0.5f;
    float startTime;
    public ToBattle battleButton;
    AudioSource mySound;

	// Use this for initialization
	void Start () {

        basex = transform.localScale.x;
        basey = transform.localScale.y;
        mySound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

     float boingspeed = 0.3f;
     float boinglength = 0.1f;

    void FixedUpdate() {
        // this.transform.localScale
        
       transform.localScale = new Vector3(basex + Mathf.PingPong(Time.time * boingspeed, boinglength),
           Mathf.PingPong(Time.time * boingspeed, boinglength) + basey, 1f);
        


        if (moving) {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = (Time.time - startTime) / travelTime;
            transform.position = Vector3.Slerp(startPos, endPos, fracJourney);
            if (fracJourney > 1f) {
                battleButton.doDance();
                moving = false; }

        }

    }

    public void moveTo(float x, float y) {
        endPos = new Vector3(x, y, 0.0f);
        startTime = Time.time;


        moving = true;
        mySound.Play();
        startPos = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f);
    }

}
