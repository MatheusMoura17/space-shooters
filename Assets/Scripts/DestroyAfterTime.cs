using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

	public float time=3;

	// Use this for initialization
	void Start () {
		Invoke("Destroy",time);
	}
	
	private void Destroy(){
		Destroy (this.gameObject);
	}
}
