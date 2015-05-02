using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour {

	//static GameObject[] dragObjects;
	static GameObject[] solidObjects;
	static GameObject[] pickObjects;
	private static string[] examples;
	private static int exampleid = 0;
	private static string hiddenObjectValue;

	// Use this for initialization
	void Start () {
		
		InitObjects();
		InitGameData();
		SetGraphics();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartGame() {

	}

	static void InitObjects() {
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

		//dragObjects = GameObject.FindGameObjectsWithTag("DragObject");
		solidObjects = GameObject.FindGameObjectsWithTag("SolidObject");
		pickObjects = GameObject.FindGameObjectsWithTag("PickObject");

	}

	static void InitGameData() {
		string mathData = MathHandler.GenerateAdditionProblemString(3,9);
		examples = mathData.Split('p');
	}

	static void SetGraphics() {
		Debug.Log(examples.Length-1 + " --- " + exampleid);
		if(examples.Length -1 > exampleid)
		{
			for(int i = 0; i<3; i++) 
			{
				solidObjects[i].GetComponent<SpriteRenderer>().sprite = Resources.Load("Numbers/number_" + examples[exampleid][i], typeof(Sprite)) as Sprite;
				solidObjects[i].name = "number_" + examples[exampleid][i];
			}

			HideRandomSolidObject();

			//Warning: ugly code below, refactor!
			System.Random r = new System.Random();
			int pos = r.Next(0, pickObjects.Length);
			pickObjects[pos%3].GetComponent<SpriteRenderer>().sprite = Resources.Load("Numbers/" + hiddenObjectValue, typeof(Sprite)) as Sprite; 
			pickObjects[pos%3].name = hiddenObjectValue;
			Debug.Log("HOV " + hiddenObjectValue);
			int n = hiddenObjectValue[hiddenObjectValue.Length-1] - '0'; //sk.mix
			Debug.Log("N " + n);
			int[] not = MathHandler.NotThisNumber(n,9,2);
			Debug.Log("NOT LENGTH " + not.Length);
			pickObjects[(pos+1)%3].GetComponent<SpriteRenderer>().sprite = Resources.Load("Numbers/number_" + not[0], typeof(Sprite)) as Sprite;
			pickObjects[(pos+1)%3].name = "number_" + not[0];
			pickObjects[(pos+2)%3].GetComponent<SpriteRenderer>().sprite = Resources.Load("Numbers/number_" + not[1], typeof(Sprite)) as Sprite;
			pickObjects[(pos+2)%3].name = "number_" + not[1];
		}
		else
		{
			Debug.Log("Game over!");
		}

		
		
	}

	static void CreateSolidObject(string name, Vector3 pos) {
		GameObject obj = Instantiate(Resources.Load("SolidPrefab", typeof(GameObject))) as GameObject;
		obj.transform.position = pos;
		obj.name = name;
	}

	static void CreateDragObject(string name, Vector3 pos) {
		GameObject obj = Instantiate(Resources.Load("DragPrefab", typeof(GameObject))) as GameObject;
		obj.transform.position = pos;
		obj.name = name;
	}

	static void CreateObject(string prefab, string name, Vector3 pos) {
		GameObject obj = Instantiate(Resources.Load(prefab, typeof(GameObject))) as GameObject;
		obj.transform.position = pos;
		obj.name = name;
	}

	static void HideRandomSolidObject() {
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
		int k = 0;
		foreach(String s in examples) {
			Debug.Log(k + " " + s);
			k++;
		}
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
				exampleid++;
				SetGraphics();
				UnpickAll();
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

	public static void UnpickAll() {
		foreach(GameObject obj in pickObjects) {
			obj.GetComponent<PickScript>().Unpick();
		}
	}

}