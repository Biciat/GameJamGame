using UnityEngine;
using System.Collections;

public class SizeBoing : MonoBehaviour {

	float basex; 
	float basey;

	// Use this for initialization
	void Start () {
		basex = transform.localScale.x;
		basey = transform.localScale.y;
	}
	
	void Update() {
		transform.localScale = new Vector3(basex + Mathf.PingPong(Time.time * 5, 10),  Mathf.PingPong(Time.time * 5, 10) + basey ,1f);
	}
}
