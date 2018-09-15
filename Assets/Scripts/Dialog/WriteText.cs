using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteText : MonoBehaviour {

	public static WriteText instance;
	public Text screenText;
	public Text placeText;
	public float letterDelay = 0.1f;
	public float dialogEndDelay = 2.0f;
	public GameObject DialogPanel;
	public GameObject PlacePanel;
	public GameObject DialogOK;
	public GameObject PlaceOK;

	[Header("Sound Clips")]
	public AudioClip keyboardSound;
	public AudioClip whatsappMessage;
	public AudioClip mobileSound;
	public AudioClip typewriterSfx;
	public AudioClip blipFemale;
	public AudioClip blipMale;
	private AudioSource m_audioSource;

	
	void Awake() {
		if(instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	public IEnumerator RenderTextRoutine(string text) {
		ActivatePanels(true, false);
		DialogOK.SetActive(false);
		screenText.text = "";

		for(int i = 0; i < text.Length; i++) {
			screenText.text += text[i];
			SoundManager.instance.PlaySfx(blipFemale);
			yield return new WaitForSeconds(letterDelay);
		}
		// yield return new WaitForSeconds(dialogEndDelay);
		DialogOK.SetActive(true);
		
	}

	public IEnumerator RenderPlaceRoutine(string text) {
		ActivatePanels(false, true);
		PlaceOK.SetActive(false);
		placeText.text = "";
		for(int i = 0; i < text.Length; i++) {
			placeText.text += text[i];
			SoundManager.instance.PlaySfx(typewriterSfx);
			yield return new WaitForSeconds(letterDelay);
		}
		// yield return new WaitForSeconds(dialogEndDelay);
		PlaceOK.SetActive(true);
	}

	public void RenderTextOnScreen(string text) {
		ActivatePanels(true, false);
		StartCoroutine(RenderTextRoutine(text));
	}

	public void RenderPlaceOnScreen(string text) {
		ActivatePanels(false, true);
		StartCoroutine(RenderPlaceRoutine(text));
	}

	public void ActivatePanels(bool dialogPanel, bool placePanel) {
		DialogPanel.SetActive(dialogPanel);
		PlacePanel.SetActive(placePanel);
	}
}
