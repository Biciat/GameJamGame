using UnityEngine;
using System.Collections;

abstract public class AliveObjectController : MonoBehaviour {


[Header("Animation options")]
public Animator anim;

[Header("Movement options")]
public float speed = 0.8f;
public float jumpPower = 200;
public bool canMove = true; 

public bool onAir = true;
public bool dJump = false;
private bool Guard = false;

public bool right = true;

[Header("Attack options")]
public BoxCollider hitBox;

	// Use this for initialization
	void Start () {
		//anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		float yin = Input.GetAxis("Vertical");
		float move = Input.GetAxis("Horizontal");
		//anim.SetFloat("Movement", Mathf.Abs(move));
	
		//face right or left
		if (move != 0 && canMove) {
			if (move < 0) {
				right = false;
			}
			else {
				right = true;
			}
			move *= Time.deltaTime*speed;
			this.transform.position += new Vector3(move,0.0f,0.0f);
		}

		
		if (Input.GetButton("Jump") && canMove) {
			if (!onAir) {
				//anim.SetBool("onAir",true);
				GetComponent<Rigidbody>().AddForce(transform.up * jumpPower);
				onAir = true;
			} else if (!dJump) {
				//anim.SetTrigger("Jump");
				GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x,0);
				GetComponent<Rigidbody>().AddForce(transform.up * jumpPower);
				dJump = true;
			}
		}
	}

	void Update() {
		if (Input.GetButton("Fire3")) {
			Debug.Log("Ataco");
			Attack ();
		}
	}

	void OnCollisionEnter(Collision crash) {
		if (crash.gameObject.layer.Equals(LayerMask.NameToLayer("Floor"))){ 		
			if (onAir) {
				//anim.SetBool("onAir",false);
				onAir = false;
				dJump = false;
			}
		}
	  }
	
	void OnCollisionExit(Collision coll) {
		if (coll.gameObject.layer == LayerMask.NameToLayer("Floor")) { 		
				//anim.SetBool("onAir",true);
				onAir = true;
				dJump = false;
		}
	
	}
	
	public abstract void Attack();
}
