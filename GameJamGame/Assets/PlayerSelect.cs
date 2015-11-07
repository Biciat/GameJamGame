using UnityEngine;
using System.Collections;

public class PlayerSelect : MonoBehaviour {

    Vector3 startPos;
    Vector3 endPos;

    bool moving = false;
    float speed = 0.2f;
    float travelTime = 1f;
    float startTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        if (moving) {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = (Time.time - startTime) / travelTime;
            transform.position = Vector3.Slerp(startPos, endPos, fracJourney);

        }

    }

    public void moveTo(float x, float y) {
        endPos = new Vector3(x, y, 0.0f);
        moving = true;
        startTime = Time.time;

        startPos = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f);


    }

}
