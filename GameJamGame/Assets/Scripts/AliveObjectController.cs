using UnityEngine;
using System.Collections;

abstract public class AliveObjectController : MonoBehaviour {


public Animator anim;
public float speed = 0.8f;
public float jumpPower = 200;

private bool onAir = true;
private bool dJump = false;
private bool Guard = false;

public bool right = true;
public GameObject hitbox;

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
		if (move != 0) {
			if (move < 0) {
				right = false;
			}
			else {
				right = true;
			}
			move *= Time.deltaTime*speed;
			this.transform.position += new Vector3(move,0.0f,0.0f);
		}

		
		if (Input.GetKeyDown(KeyCode.Space)) {
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

	private void readyHit() 
	{
		int r = 1;
		if (!right) r =-1; 
		hitbox.GetComponent<Hitbox>().direction = r*this.transform.right + this.transform.up*3f;
		//anim.SetTrigger("Attack");
	}
	
	public void Hit() 
	{
		hitbox.GetComponent<Collider2D>().enabled= true;
	}
	
	public void EndHit() 
	{
		hitbox.GetComponent<Collider2D>().enabled= false;
	}
	
	
	void OnCollisionEnter(Collision crash) {
		if (crash.gameObject.layer == LayerMask.NameToLayer("Floor")){ 		
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
