﻿using UnityEngine;
using System.Collections;

public class PickScript : MonoBehaviour {

	public bool picked = false;
	Vector3 bump = new Vector3(0,0.1f,0);

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		picked = !picked;
		GameManager.UnpickOthers(gameObject);
		if(picked) {
			this.transform.position += bump;
			this.transform.localScale *= 1.25f;
		} 
		else {
			this.transform.position -= bump;
			this.transform.localScale *= 0.8f;
		} 
	}

	public void Unpick() {
		if(picked) {
		picked = false;
		this.transform.position -= bump;
		this.transform.localScale *= 0.8f;
		}
	}
}
