using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public Transform target;
	public float offsetZ=10;
	public float offsetY=3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target && target.gameObject.activeSelf) {
			transform.eulerAngles = target.eulerAngles;
			transform.position = target.position - (target.forward * offsetZ) + (target.up * offsetY);
		}
	}
}
