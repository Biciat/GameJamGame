using UnityEngine;
using System.Collections;

public class ToastAliveThatIsAlive : MonoBehaviour {
	//Public
	[Tooltip("It has to be private and taken from PlayerManager")]
	public string self;
	public int damage;
	public GameObject puff;
	public AudioClip sound;
	// Use this for initialization
	void Start () {
		puff = Resources.Load ("SmokePuff") as GameObject;
	}
	private void DestroyToast(){
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other){
		GetComponent<AudioSource>().PlayOneShot(sound);
		if (other.tag != self) {
			if(other.gameObject.GetComponent<AliveObjectStats>() != null){
				other.gameObject.GetComponent<AliveObjectStats>().getHurt(damage);
				GameObject obj = Instantiate(puff, transform.position, Quaternion.identity) as GameObject;
			}
			DestroyToast();
		}
	}
}
