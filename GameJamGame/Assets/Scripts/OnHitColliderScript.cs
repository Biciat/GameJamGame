using UnityEngine;
using System.Collections;

public class OnHitColliderScript : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		bool hitBoxEnabled = GetComponent<BoxCollider>().enabled; 
		if (hitBoxEnabled) {
			if (other.gameObject.tag == "Player" ){
				int damageAmount = GetComponentInParent<AliveObjectStats>().attackDamage;
				other.gameObject.GetComponent<AliveObjectStats>().getHurt (damageAmount);
				Debug.Log("PPPPPPPPPPPPPPPAAAAAAAAAAAAAAAAAAAAAAAAM");
			}
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
