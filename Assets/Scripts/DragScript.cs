using UnityEngine;
using System.Collections;

public class DragScript : MonoBehaviour {

	private bool draggable = false;
	private float distance;

	// Use this for initialization
	void Start () {
		Debug.Log("DragScript for " + transform.name  +" started!");
	}

	void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        draggable = true;
    }
 
    public void OnMouseUp()
    {
        draggable = false;
    }
 
    void Update()
    {
        if (draggable)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }
}
