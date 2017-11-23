using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public float speed=10;
	public float timeToDestroy=3;
	public GameObject effectPrefab;

	// Use this for initialization
	void Start () {
		Invoke ("Destroy",timeToDestroy);
	}

	private void Destroy(){
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		Instantiate (effectPrefab, transform.position, transform.rotation);
		Destroy();
	}
}
