using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;
	public AudioSource m_musicSource;
	public AudioSource m_sfxSource;

	void Awake() {
		if(instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	public void PlaySfx(AudioClip audio) {
		m_sfxSource.clip = audio;
		m_sfxSource.Play();
	}
}
