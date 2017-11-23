using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour {



	public static soundmanager instance;
	public AudioClip explosaoSound;
	public AudioClip tiroSound;
	public AudioClip turbinaSound;
	public AudioClip danoSound;

	// Use this for initialization
	void Awake(){
		if (instance != null) {

			Debug.LogError ("Existem múltiplas instâncias do script Soundmanager.");
		}
		instance = this;
	}


	public void MakeExplosionSound()
	{
		MakeSound (explosaoSound);
	}

	public void MakePlayerShotSound()
	{
		MakeSound (tiroSound);
	}
	public void MakeTurbinaSound()
	{
		MakeSound (turbinaSound);
	}

	public void MakeDanoSound()
	{
		MakeSound (danoSound);
	}


	private void MakeSound(AudioClip originalClip)
	{
		AudioSource.PlayClipAtPoint (originalClip, transform.position);
	}




			void Start () {
				
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
