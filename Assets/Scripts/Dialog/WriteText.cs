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

	[Header("Sound Clips")]
	public AudioClip keyboardSound;
	public AudioClip whatsappMessage;
	public AudioClip mobileSound;
	private AudioSource m_audioSource;

	
	void Awake() {
		if(instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	void Start() {
		m_audioSource = GetComponent<AudioSource>();
		StartCoroutine(PlayDialog());
	}
	
	private IEnumerator PlayDialog() {
		m_audioSource.clip = keyboardSound;

		yield return StartCoroutine(RenderPlaceRoutine("13 de Setembro de 2023\nQuarto da Damires"));

		m_audioSource.clip = mobileSound;

		yield return StartCoroutine(RenderTextRoutine("Ah, o que eu não faria para ter um sugar daddy igual ao Roberval."));
		yield return StartCoroutine(RenderTextRoutine("Eu não aguento mais perder minhas férias para ouvir 'Você só fez sua obrigação!!'"));

		// abrulho do whatsapp
		yield return StartCoroutine(PlayAudioWithDelay(whatsappMessage));
		

		yield return StartCoroutine(RenderTextRoutine("EITA! O Pablo Vittar liberou o Lula da prisão junto com a Gretchen."));
		yield return StartCoroutine(RenderTextRoutine("Agora ele foi longe demais!!!"));

		// abrulho do whatsapp
		yield return StartCoroutine(PlayAudioWithDelay(whatsappMessage));

		m_audioSource.clip = keyboardSound;
		yield return StartCoroutine(RenderTextRoutine("E O QQQQQQQQQQ"));
		yield return StartCoroutine(RenderTextRoutine("Esse paquiderme me reprovou por 1 décimo!?"));

		yield return StartCoroutine(RenderTextRoutine("Vou ter que enfrentar meu pior inimigo!"));
		yield return StartCoroutine(RenderTextRoutine("O Sol das 15."));
	}

	private IEnumerator PlayAudioWithDelay(AudioClip audio) {
		m_audioSource.PlayOneShot(audio);
		yield return new WaitForSeconds(dialogEndDelay);
	}

	private IEnumerator RenderTextRoutine(string text) {
		ActivatePanels(true, false);
		screenText.text = "";
		m_audioSource.Play();
		for(int i = 0; i < text.Length; i++) {
			screenText.text += text[i];
			yield return new WaitForSeconds(letterDelay);
		}

		m_audioSource.Stop();

		yield return new WaitForSeconds(dialogEndDelay);
		ActivatePanels(false, false);
	}

	private IEnumerator RenderPlaceRoutine(string text) {
		ActivatePanels(false, true);
		placeText.text = "";
		m_audioSource.Play();
		for(int i = 0; i < text.Length; i++) {
			placeText.text += text[i];
			yield return new WaitForSeconds(letterDelay);
		}
		
		m_audioSource.Stop();

		yield return new WaitForSeconds(dialogEndDelay);
		ActivatePanels(false, false);
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
