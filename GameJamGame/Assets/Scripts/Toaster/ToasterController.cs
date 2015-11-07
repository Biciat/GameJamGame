using UnityEngine;
using System.Collections;

public class ToasterController : AliveObjectController {
	
	//Public
	public float toastSpeed = 3.0f;
	public int maxToasts = 2;
	public int toastDamage = 1;
	public float rechargeTime = 0.75f;
	
	//Private
	private GameObject toast;
	private float rateCounter = 0.05f;
	private float cont = 0.0f;
	private int shotToasts = 0;
	private float recharge_cont = 0;
	private bool onRecharge = false;
	private float shotIdle = 0;
	private float shotIdleTime = 0.5f;
	private GameObject toasterSpot;
	
	void Start () {
		//Load toast prefab
		toast = Resources.Load ("Toast") as GameObject;
		cont = rateCounter;
		toasterSpot = transform.FindChild ("ToastMakerSpot").gameObject;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow) && shotToasts < maxToasts){
			if(cont >= rateCounter){
				cont = 0;
				shotIdle = 0;
				Attack();
			}
		}
		else shotIdle += Time.deltaTime;
		if(shotIdle >= shotIdleTime && shotToasts < maxToasts){
			shotToasts = 0;
			cont = rateCounter;
		}
		if (cont < rateCounter)
			cont += Time.deltaTime;
		if (shotToasts >= maxToasts) {
			onRecharge = true;
		}
		if (onRecharge)
			recharge_cont += Time.deltaTime;
		if (recharge_cont >= rechargeTime) {
			recharge_cont = 0;
			shotToasts = 0;
			onRecharge = false;
		}
	}
	
	public override void Attack() {
		Debug.Log ("<color=purple>Eat that fucking toast bitch!</color>");
		ShotToast ();
	}
	
	public void ShotToast(){
		GameObject new_toast = Instantiate (toast, toasterSpot.transform.position, Quaternion.identity) as GameObject;
		Debug.Log (transform.tag);
		new_toast.GetComponent<ToastAliveThatIsAlive> ().self = transform.tag;
		new_toast.GetComponent<ToastAliveThatIsAlive> ().damage = toastDamage;
		if (transform.GetComponent<AliveObjectController> ().right) {
			new_toast.GetComponent<Rigidbody> ().AddForce (toastSpeed * transform.right);
		} else {
			new_toast.GetComponent<Rigidbody> ().AddForce (-toastSpeed * transform.right);
		}
		++shotToasts;
		Destroy (new_toast, 4.0f);
	}
}