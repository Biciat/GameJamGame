using UnityEngine;
using System.Collections;

public class ToasterController : AliveObjectController {

	//Public
	public float fireRate = 3.0f;
	public float toastSpeed = 3.0f;
	public int maxToasts = 3;

	//Private
	private GameObject toast;
	private float rateCounter = 0.2f;

	void Start () {
		//Load toast prefab
		toast = Resources.Load ("Toast") as GameObject;
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			Attack();
		}
	}

 	public override void Attack() {
		Debug.Log ("Ataco!");
		ShotToast ();
	}

	public void ShotToast(){
		GameObject new_toast = Instantiate (toast, transform.position, Quaternion.identity) as GameObject;
		if (transform.GetComponent<AliveObjectController> ().right) {
			new_toast.GetComponent<Rigidbody> ().AddForce (toastSpeed * transform.right);
		} else {
			new_toast.GetComponent<Rigidbody> ().AddForce (-toastSpeed * transform.right);
		}
	}
}
