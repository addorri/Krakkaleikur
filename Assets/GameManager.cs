using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CreateDragObject("drag1", new Vector3(-1,-4,0));
		CreateDragObject("drag2", new Vector3(0,-4,0));
		CreateDragObject("drag3", new Vector3(1,-4,0));

		CreateSolidObject("first", new Vector3(-1,4,0));
		CreateSolidObject("second", new Vector3(0,4,0));
		CreateSolidObject("third", new Vector3(1,4,0));

		HideRandomSolidObject();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateSolidObject(string name, Vector3 pos) {
		GameObject obj = Instantiate(Resources.Load("SolidPrefab", typeof(GameObject))) as GameObject;
		obj.transform.position = pos;
		obj.name = name;
		obj.tag = "SolidObject";
	}

	void CreateDragObject(string name, Vector3 pos) {
		GameObject obj = Instantiate(Resources.Load("DragPrefab", typeof(GameObject))) as GameObject;
		obj.transform.position = pos;
		obj.name = name;
		obj.tag = "DragObject";
	}

	void HideRandomSolidObject() {
		GameObject[] go = GameObject.FindGameObjectsWithTag("SolidObject");
		System.Random r = new System.Random();
		int pick = r.Next(0, go.Length);
		go[pick].renderer.enabled = false;
	}

}