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
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		anim = gameObject.GetComponent<Animator>();
		float yin = 0;//= Input.GetAxis("Vertical");
		float move = 0;// = Input.GetAxis("Horizontal");

		if (transform.tag == "Player1") {
			 yin = Input.GetAxis("Vertical");
			 move = Input.GetAxis("Horizontal");
		}
		else if (transform.tag == "Player2") {
			yin = Input.GetAxis("Vertical2");
			move = Input.GetAxis("Horizontal2");
		}


		//face right or left
		if (move != 0 && canMove) {
			if (move < 0) {
				right = false;
				walk_l();
			} else {
				right = true;
				walk_r();
			}
			move *= Time.deltaTime * speed;
			this.transform.position += new Vector3 (move, 0.0f, 0.0f);
		} else if (move == 0 && !anim.GetBool("attack") && !anim.GetBool("jump")) {
			idle();

		}

		Vector3 down = transform.TransformDirection(Vector3.down);
		RaycastHit hit;
		float distanceToGround = 0;
		if (Input.GetButtonUp ("Jump")) {
			counterAllow = true;
		}

		if (Input.GetKey(KeyCode.Space) && transform.tag == "Player1" && canMove) {
			if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0F)) {
				distanceToGround = hit.distance;
			}
			
			if (distanceToGround < 0.1 ) { //&& !onAir) {
				//anim.SetBool("onAir",true);
				GetComponent<Rigidbody>().AddForce(transform.up * jumpPower);
				jump();
				isJumping = true;
			}
			if (!dJump && counterAllow) {
				//anim.SetTrigger("Jump");
				GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x,0,0);
				GetComponent<Rigidbody>().AddForce((transform.up * jumpPower));
				jump();
				dJump = true;
				counterAllow = false;
			}
		}
		else if (Input.GetKey(KeyCode.JoystickButton0) && transform.tag == "Player2" && canMove) {
			if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0F)) {
				distanceToGround = hit.distance;
			}
			
			if (distanceToGround < 0.1 ) { //&& !onAir) {
				//anim.SetBool("onAir",true);
				GetComponent<Rigidbody>().AddForce(transform.up * jumpPower);
				jump();
				isJumping = true;
			}
			if (!dJump && counterAllow) {
				//anim.SetTrigger("Jump");
				GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x,0,0);
				GetComponent<Rigidbody>().AddForce((transform.up * jumpPower));
				jump();
				dJump = true;
				counterAllow = false;
			}
		}
		if (Input.GetKeyDown (KeyCode.E) && transform.tag == "Player1") {
			Attack ();
		}
		else if (Input.GetKeyDown (KeyCode.Keypad0) && transform.tag == "Player2") {
			Attack ();
		}
	}

	void Update() {

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

	public void idle(){
		anim.SetBool ("idle", true);
		anim.SetBool ("walk_l", false);
		anim.SetBool ("walk_r", false);
		anim.SetBool ("jump", false);
		anim.SetBool ("attack", false);
	}
	private void walk_r(){
		anim.SetBool ("idle", false);
		anim.SetBool ("walk_l", false);
		anim.SetBool ("walk_r", true);
		anim.SetBool ("jump", false);
		anim.SetBool ("attack", false);
	}
	private void walk_l(){
		anim.SetBool ("idle", false);
		anim.SetBool ("walk_l", true);
		anim.SetBool ("walk_r", false);
		anim.SetBool ("jump", false);
		anim.SetBool ("attack", false);
	}
	private void jump(){
		anim.SetBool ("idle", false);
		anim.SetBool ("walk_l", false);
		anim.SetBool ("walk_r", false);
		anim.SetBool ("jump", true);
		anim.SetBool ("attack", false);
	}
	public void attack(){
		anim.SetBool ("idle", false);
		anim.SetBool ("walk_l", false);
		anim.SetBool ("walk_r", false);
		anim.SetBool ("jump", false);
		anim.SetBool ("attack", true);
	}
	
	public abstract void Attack();
}
