using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour {

	GameObject[] dragObjects;
	GameObject[] solidObjects;
	static GameObject[] pickObjects;
	private string[] examples;
	private static string hiddenObjectValue;

	// Use this for initialization
	void Start () {
		
		InitObjects();
		InitGameData();
		SetGraphics();
		
		HideRandomSolidObject();

		pickObjects[0].GetComponent<SpriteRenderer>().sprite = Resources.Load("Numbers/" + hiddenObjectValue, typeof(Sprite)) as Sprite;
		pickObjects[0].name = hiddenObjectValue;
		Debug.Log("HOV " + hiddenObjectValue);
		int n = hiddenObjectValue[hiddenObjectValue.Length-1] - '0'; //sk.mix
		Debug.Log("N " + n);
		int[] not = MathHandler.NotThisNumber(n,9,2);
		Debug.Log("NOT LENGTH " + not.Length);
		pickObjects[1].GetComponent<SpriteRenderer>().sprite = Resources.Load("Numbers/number_" + not[0], typeof(Sprite)) as Sprite;
		pickObjects[1].name = "number_" + not[0];
		pickObjects[2].GetComponent<SpriteRenderer>().sprite = Resources.Load("Numbers/number_" + not[1], typeof(Sprite)) as Sprite;
		pickObjects[2].name = "number_" + not[1];

		string k = MathHandler.GenerateAdditionProblemString(5,9);
		Debug.Log("split1 " + k.Split('p')[0]);
		Debug.Log("split2 " + k.Split('p')[1]);
		string l = MathHandler.GenerateSubtractionProblemString(5,9);
		Debug.Log("split3 " + l.Split('m')[0]);
		Debug.Log("split4 " + l.Split('m')[1]);

		

		int[] test = MathHandler.NotThisNumber(8);
		foreach(int i in test) Debug.Log("Not " + i);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitObjects() {
		//CreateDragObject("drag1", new Vector3(-1,-4,0));
		//CreateDragObject("drag2", new Vector3(0,-4,0));
		//CreateDragObject("drag3", new Vector3(1,-4,0));

		CreateObject("SolidPrefab", "solid1", new Vector3(-5,4,0));
		CreateObject("SolidPrefab", "solid2", new Vector3(0,4,0));
		CreateObject("SolidPrefab", "solid3", new Vector3(5,4,0));

		CreateObject("PickPrefab", "pick1", new Vector3(-4,-3,0));
		CreateObject("PickPrefab", "pick2", new Vector3(0,-3,0));
		CreateObject("PickPrefab", "pick3", new Vector3(4,-3,0));

		GameObject checkButton = Instantiate(Resources.Load("ButtonPrefab", typeof(GameObject))) as GameObject;

		dragObjects = GameObject.FindGameObjectsWithTag("DragObject");
		solidObjects = GameObject.FindGameObjectsWithTag("SolidObject");
		pickObjects = GameObject.FindGameObjectsWithTag("PickObject");

	}

	void InitGameData() {
		string mathData = MathHandler.GenerateAdditionProblemString(20,9);
		examples = mathData.Split('p');
	}

	void SetGraphics() {
		for(int i = 0; i<3; i++) {
			solidObjects[i].GetComponent<SpriteRenderer>().sprite = Resources.Load("Numbers/number_" + examples[0][i], typeof(Sprite)) as Sprite;
			solidObjects[i].name = "number_" + examples[0][i];
		}
		
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
		Debug.Log("Object hidden has name " + solidObjects[pick].name);
		hiddenObjectValue = solidObjects[pick].name;
	}

	/*string HideRandomSolidObject() {
		foreach(GameObject obj in solidObjects) obj.renderer.enabled = true;
		System.Random r = new System.Random();
		int pick = r.Next(0, solidObjects.Length);
		solidObjects[pick].renderer.enabled = false;
		return solidObjects[pick].name;
	}*/

	public static void CheckSolution() {
		int count = 0;
		string value = "";
		Debug.Log("Checking solution!");
		foreach(GameObject obj in pickObjects) {
			if(obj.GetComponent<PickScript>().picked) {
			Debug.Log(obj.name + " picked!");
			count++;
			value = obj.name;
			}
		}
		if(count == 1) {
			if(value.Equals(hiddenObjectValue)) {
				Debug.Log("RÉTT SVAR!");
			} else {
				Debug.Log("RANGT SVAR!");
			}
		} else {
			Debug.Log("EKKI VERA HEIMSKUR!");
		}
	}

	public static void UnpickOthers(GameObject obj) {
		foreach(GameObject other in pickObjects) {
			if(!obj.Equals(other)) {
				other.GetComponent<PickScript>().Unpick();
			}
		}
	}

}