﻿using UnityEngine;
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
		if (remainingLife <= 0) {
			dead=true;
		}
	}

	public void resetStats() {
		remainingLife = hitsToDie;
		dead = false;
	}

	public bool isDead() {
		return dead;
	}
}