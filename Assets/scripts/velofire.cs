using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velofire : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject nave01;
        nave01 = GameObject.Find("default");

        GetComponent<Rigidbody>().AddForce(nave01.transform.position * 100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
