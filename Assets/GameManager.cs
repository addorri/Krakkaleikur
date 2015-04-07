using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour {

	GameObject[] dragObjects;
	GameObject[] solidObjects;
	static GameObject[] pickObjects;

	// Use this for initialization
	void Start () {
		CreateDragObject("drag1", new Vector3(-1,-4,0));
		CreateDragObject("drag2", new Vector3(0,-4,0));
		CreateDragObject("drag3", new Vector3(1,-4,0));

		CreateSolidObject("solid1", new Vector3(-1,4,0));
		CreateSolidObject("solid2", new Vector3(0,4,0));
		CreateSolidObject("solid3", new Vector3(1,4,0));

		CreateObject("PickPrefab", "pick1", new Vector3(-1,-3,0));
		CreateObject("PickPrefab", "pick2", new Vector3(0,-3,0));
		CreateObject("PickPrefab", "pick3", new Vector3(1,-3,0));
		
		GameObject checkButton = Instantiate(Resources.Load("ButtonPrefab", typeof(GameObject))) as GameObject;

		dragObjects = GameObject.FindGameObjectsWithTag("DragObject");
		solidObjects = GameObject.FindGameObjectsWithTag("SolidObject");
		pickObjects = GameObject.FindGameObjectsWithTag("PickObject");

		string k = MathHandler.GenerateAdditionProblemString(5,9);
		Debug.Log("split " + k.Split('p')[0]);

		HideRandomSolidObject();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateSolidObject(string name, Vector3 pos) {
		GameObject obj = Instantiate(Resources.Load("SolidPrefab", typeof(GameObject))) as GameObject;
		obj.transform.position = pos;
		obj.name = name;
	}

	void CreateDragObject(string name, Vector3 pos) {
		GameObject obj = Instantiate(Resources.Load("DragPrefab", typeof(GameObject))) as GameObject;
		obj.transform.position = pos;
		obj.name = name;
	}

	void CreateObject(string prefab, string name, Vector3 pos) {
		GameObject obj = Instantiate(Resources.Load(prefab, typeof(GameObject))) as GameObject;
		obj.transform.position = pos;
		obj.name = name;
	}

	void HideRandomSolidObject() {
		foreach(GameObject obj in solidObjects) obj.renderer.enabled = true;
		System.Random r = new System.Random();
		int pick = r.Next(0, solidObjects.Length);
		solidObjects[pick].renderer.enabled = false;
	}

	public static void CheckSolution() {
		Debug.Log("Checking solution!");

		foreach(GameObject obj in pickObjects) {
			if(obj.GetComponent<PickScript>().picked) Debug.Log(obj.name + " picked!");
		}
	}

}