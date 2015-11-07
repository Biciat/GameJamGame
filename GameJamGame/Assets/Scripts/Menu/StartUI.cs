using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartUI : MonoBehaviour {
    bool move = false;
    float speed = 800f;
    RectTransform rTransform;
    public SlotSelector p1;
    public SlotSelector p2;
    float targetY;

	// Use this for initialization
	void Start () {
        rTransform= this.GetComponent<RectTransform>();
        targetY = Screen.height / 2;
        move = true;

    }

    // Update is called once per frame
    void Update () {

        if (move) {

            rTransform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
            if (rTransform.position.y < targetY) {
                move = false;
                p1.enabled = true;
                p2.enabled = true;
            }

        }
	
	}
}
