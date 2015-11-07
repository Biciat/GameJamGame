using UnityEngine;
using System.Collections;

public class BeaterController : AliveObjectController {

	[Header("Animation options")]
	public float animationAttackTime = 2.0f; 

	[Header("Dizziness options")]
	public float dizzinessMax = 10f; 
	public float dizziPerClick = 2f; 
	public float secondsToResetDizziness = 2.0f; 

	private bool isAttacking = false;
	private float currentDizziness; 
	private float timeElapsedSinceLastClick; 
	public override void Attack ()
	{
		if (timeElapsedSinceLastClick >= secondsToResetDizziness) {
			currentDizziness = 0f; 
		} 
		if (!isAttacking) {
			StartCoroutine ("startAttack");
		}
		currentDizziness += dizziPerClick; 
		if (currentDizziness >= dizzinessMax) {
			Debug.Log ("FUUU QUE MAREOOOO"); 
		}
	}

	// Use this for initialization
	void Start () {

	}

	IEnumerator startAttack() {
		isAttacking = true;
		hitBox.GetComponent<BoxCollider> ().enabled = true;
		yield return new WaitForSeconds(animationAttackTime);
		hitBox.GetComponent<BoxCollider> ().enabled = false; 
		isAttacking = false; 
	}

}
