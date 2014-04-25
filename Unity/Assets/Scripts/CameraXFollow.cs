using UnityEngine;
using System.Collections;

public class CameraXFollow : MonoBehaviour {

	float startOffset;
	public GameObject target;
	
	// Use this for initialization
	void Start () {
		startOffset = gameObject.transform.position.x - target.transform.position.x;
		Vector3 position = gameObject.transform.position; 
		position.y = target.transform.position.y;
		gameObject.transform.position = position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = gameObject.transform.position; 
		position.x = target.transform.position.x + startOffset;
		gameObject.transform.position = position;
	}
}
