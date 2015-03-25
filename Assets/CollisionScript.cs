using UnityEngine;
using System.Collections;
using System.Threading;

public class CollisionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Collision Script started for " + this.gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("Collision with object " + coll.gameObject.name);        
    }

    void OnTriggerStay2D(Collider2D coll) {
    	Debug.Log(this.gameObject.name + " has had a Trigger event with object " + coll.gameObject.name);
    	//this.GetComponent<DragScript>().enabled = false;
       	this.transform.position = coll.transform.position;
    }

}
