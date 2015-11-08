using UnityEngine;
using System.Collections;

public class AliveObjectStats : MonoBehaviour {

	public int hitsToDie=3;
	public int attackDamage=1;

	private bool dead;
	private int remainingLife;

	// Use this for initialization
	void Start () {
		resetStats ();
	}

	public void getHurt(int damageReceived) {
		remainingLife -= damageReceived;
		GetComponent<Animator> ().SetBool ("hit", true);
		if (remainingLife <= 0) {
			dead=true;
			Die();
		}
	}

	public void resetStats() {
		remainingLife = hitsToDie;
		dead = false;
	}

	public bool isDead() {
		return dead;
	}

	private void Die() {
		GetComponent<Animator> ().SetBool ("die", true);
		Destroy (gameObject, 3.0f); 
	}
}
