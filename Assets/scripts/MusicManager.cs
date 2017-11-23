using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour {

	public enum MusicNames{
		NONE,
		MENU,
		GAME
	}

	public static MusicManager instance;
	public AudioClip menuMusic;
	public AudioClip gamePlayMusic;
	private AudioSource musicSource;

	private MusicNames currentMusic=MusicNames.NONE;

	void Awake(){
		instance = this;
		musicSource = GetComponent<AudioSource> ();
		musicSource.loop = true;
		musicSource.playOnAwake = false;
	}

	public void PlayMusic(MusicNames music){
		if (currentMusic != music) {
			
			if(musicSource.isPlaying)
				musicSource.Stop ();
			currentMusic = music;

			switch (music) {
			case MusicNames.MENU:
				{
					musicSource.clip = menuMusic;
					musicSource.Play ();
				}
				break;
			case MusicNames.GAME:
				{
					musicSource.clip = gamePlayMusic;
					musicSource.Play ();
				}
				break;
			}
		}
	}
}
