using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour {

	private Transform target;

	void Start(){
		target = FindObjectOfType<Camera>().transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
	}
}
