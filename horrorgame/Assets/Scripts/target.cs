﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {

	public float health = 50f;

	public void TakeDamage(float amount) {
		health -= amount;
		if (health <= 0) {
			die ();
		}
	}

	void die() {
		Destroy (gameObject);
	}
}

