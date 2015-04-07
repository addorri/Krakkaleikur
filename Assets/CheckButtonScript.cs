using UnityEngine;
using System.Collections;

public class CheckButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("CheckButtonScript started!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() {
		this.renderer.enabled = false;
	}

	void OnMouseExit() {
		this.renderer.enabled = true;
	}

	void OnMouseDown() {
		GameManager.CheckSolution();
	}
}
