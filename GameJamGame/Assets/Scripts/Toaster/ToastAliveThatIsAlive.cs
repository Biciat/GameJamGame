using UnityEngine;
using System.Collections;

public class ToastAliveThatIsAlive : MonoBehaviour {
	//Public
	[Tooltip("It has to be private and taken from PlayerManager")]
	public string self;
	public int damage;
	// Use this for initialization
	void Start () {
	
	}
	private void DestroyToast(){
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag != self) {
			if(other.gameObject.GetComponent<AliveObjectStats>() != null){
				other.gameObject.GetComponent<AliveObjectStats>().getHurt(damage);
				DestroyToast();

			}
		}
	}
}
