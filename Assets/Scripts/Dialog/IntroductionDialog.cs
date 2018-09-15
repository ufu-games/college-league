using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionDialog : MonoBehaviour {

	[Header("Sons Auxiliares")]
	public AudioClip messageBeep;
	public AudioClip shockSfx;
	private int m_currentState = 0;
	private AudioSource m_myAudioSource;
	bool m_canPress;

	void Start () {
		m_myAudioSource = GetComponent<AudioSource>();
		EvaluateState(m_currentState);
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Space) && m_canPress) {
			m_currentState++;
			EvaluateState(m_currentState);
		}
	}

	private void EvaluateState(int state) {
		switch(state) {
			case 0:
				StartCoroutine(RenderPlace("13 de Setembro de 2023\nQuarto da Damires"));
			break;
			case 1:
				StartCoroutine(RenderDialog("Ah... O que eu nao faria para ter um Sugar Daddy igual ao Roberval."));
			break;
			case 2:
				StartCoroutine(RenderDialog("Eu nao aguento mais perder minha serie so para ouvir 'Voce so fez sua obrigacao'..."));
			break;
			case 3:
				WriteText.instance.ActivatePanels(false, false);
				SoundManager.instance.PlaySfx(messageBeep);
			break;
			case 4:
				StartCoroutine(RenderDialog("EITA! O Pabllo Vittar liberou o Lula da prisao junto da Gretchen."));
			break;
			case 5:
				StartCoroutine(RenderDialog("Agora ele foi longe demais!!!"));
			break;
			case 6:
				WriteText.instance.ActivatePanels(false, false);
				SoundManager.instance.PlaySfx(messageBeep);
			break;
			case 7:
				Camera.main.GetComponent<Screenshake>().ShakeScreen(0.1f);
				m_myAudioSource.PlayOneShot(shockSfx);
				StartCoroutine(RenderDialog("Y uke!!!"));
			break;
			case 8:
				StartCoroutine(ReprovouRoutine());
			break;
			case 9:
				StartCoroutine(RenderDialog("Nao acredito que vou ter que ir chorar nota..."));
			break;
			case 10:
				StartCoroutine(RenderDialog("Vou ter que enfrentar meu pior inimigo."));
			break;
			case 11:
				Camera.main.GetComponent<Screenshake>().ShakeScreen(0.1f);
				m_myAudioSource.PlayOneShot(shockSfx);
				StartCoroutine(RenderDialog("O Sol das 15."));
			break;
			case 12:
				SceneManager.LoadScene("DialogoProfessor");
			break;
			default:
				WriteText.instance.ActivatePanels(false, false);
			break;
		}
	}

	private IEnumerator ReprovouRoutine() {
		m_canPress = false;

		Camera.main.GetComponent<Screenshake>().ShakeScreen(0.2f);
		m_myAudioSource.PlayOneShot(shockSfx);
		yield return StartCoroutine(WriteText.instance.RenderTextRoutine("ESSE PAQUIDERME ME REPROVOU"));
		yield return new WaitForSeconds(0.5f);
		Camera.main.GetComponent<Screenshake>().ShakeScreen(0.1f);
		m_myAudioSource.PlayOneShot(shockSfx);
		yield return StartCoroutine(WriteText.instance.RenderTextRoutine("POR"));
		yield return new WaitForSeconds(0.5f);
		Camera.main.GetComponent<Screenshake>().ShakeScreen(0.1f);
		m_myAudioSource.PlayOneShot(shockSfx);
		yield return StartCoroutine(WriteText.instance.RenderTextRoutine("1 (UM)"));
		yield return new WaitForSeconds(0.5f);
		Camera.main.GetComponent<Screenshake>().ShakeScreen(0.1f);
		m_myAudioSource.PlayOneShot(shockSfx);
		yield return StartCoroutine(WriteText.instance.RenderTextRoutine("PONTO!"));
		yield return new WaitForSeconds(0.5f);

		m_canPress = true;
	}
	private IEnumerator RenderPlace(string text) {
		m_canPress = false;
		yield return StartCoroutine(WriteText.instance.RenderPlaceRoutine(text));
		m_canPress = true;
	}

	private IEnumerator RenderDialog(string text) {
		m_canPress = false;
		yield return StartCoroutine(WriteText.instance.RenderTextRoutine(text));
		m_canPress = true;
	}
}
