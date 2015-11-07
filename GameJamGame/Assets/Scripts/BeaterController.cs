using UnityEngine;
using System.Collections;

public class BeaterController : AliveObjectController {

	[Header("Animation options")]
	public float animationAttackTime = 2.0f; 

	[Header("Dizziness options")]
	public float dizzinessMax = 10f; 
	public float dizziPerClick = 2f; 
	public float secondsToResetDizziness = 2.0f; 
	public float secondsDizzy = 3.0f; 

	private bool isAttacking = false;
	private float currentDizziness; 
	private float lastAttack; 
	private bool dizzy = false; 

	public override void Attack ()
	{
		if (!dizzy) {
			if (Time.time - lastAttack >= secondsToResetDizziness) {
				currentDizziness = 0f; 
			} 
			lastAttack = Time.time; 
			if (!isAttacking) {
				StartCoroutine ("StartAttack");
			}
			currentDizziness += dizziPerClick; 
			if (currentDizziness >= dizzinessMax) {
				Debug.Log ("FUUU QUE MAREOOOO"); 
				StartCoroutine ("Dizzy");
			}
		}
	}

	// Use this for initialization
	void Start () {

	}

	IEnumerator Dizzy() {
		dizzy = true; 
		canMove = false; 
		yield return new WaitForSeconds (secondsDizzy); 
		dizzy = false; 
		canMove = true; 
	}

	IEnumerator StartAttack() {
		isAttacking = true;
		hitBox.GetComponent<BoxCollider> ().enabled = true;
		yield return new WaitForSeconds(animationAttackTime);
		hitBox.GetComponent<BoxCollider> ().enabled = false; 
		isAttacking = false; 
	}

}
