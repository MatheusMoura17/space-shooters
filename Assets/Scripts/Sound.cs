using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour {

	public AudioClip explosaoSound;
	public AudioClip tiroSound;
	public AudioClip turbinaSound;
	public AudioClip danoSound;
	private AudioSource source;

	void Start(){
		source = GetComponent<AudioSource> ();
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
		source.PlayOneShot (originalClip);
	}
}
