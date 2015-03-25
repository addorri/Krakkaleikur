using UnityEngine;
using System.Collections;

public class PickScript : MonoBehaviour {

	bool picked = false;
	Vector3 bump = new Vector3(0,0.1f,0);
	Vector3 scaleUp = new Vector3(1.25f, 1.25f, 1.25f);
	Vector3 scaleDown = new Vector3(0.8f, 0.8f, 0.8f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		picked = !picked;
		if(picked) {
			this.transform.position += bump;
			this.transform.localScale *= 1.25f;
		} 
		else {
			this.transform.position -= bump;
			this.transform.localScale *= 0.8f;
		} 
	}

}
