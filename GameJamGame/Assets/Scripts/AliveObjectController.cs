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
public bool isJumping= false;
private bool Guard = false;
private bool counterAllow =false;
private float dJumpTime = 0.05f;
private float dCounter =0; 
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

		Vector3 down = transform.TransformDirection(Vector3.down);
		RaycastHit hit;
		float distanceToGround = 0;
		if (Input.GetButtonUp ("Jump")) {
			counterAllow = true;
		}
		if (Input.GetButton("Jump") && canMove) {
			if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0F)) {
				distanceToGround = hit.distance;
			}
			
			if (distanceToGround < 0.1 ) { //&& !onAir) {
				//anim.SetBool("onAir",true);
				GetComponent<Rigidbody>().AddForce(transform.up * jumpPower);
				isJumping = true;
			}
			if (!dJump && counterAllow) {
				//anim.SetTrigger("Jump");
				GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x,0,0);
				GetComponent<Rigidbody>().AddForce((transform.up * jumpPower));
				dJump = true;
				counterAllow = false;
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
			//anim.SetBool("onAir",false);
			dJump = false;
			isJumping = false;
			counterAllow = false;
		}
	  }
	
	void OnCollisionExit(Collision coll) {
		if (coll.gameObject.layer == LayerMask.NameToLayer("Floor")) { 		
				//anim.SetBool("onAir",true);
				dJump = false;
		}
	}
	
	public abstract void Attack();
}
