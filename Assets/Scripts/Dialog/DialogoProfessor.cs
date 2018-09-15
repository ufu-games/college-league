using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogoProfessor : MonoBehaviour {

	public AudioClip objectionAudio;
	public AudioClip audioUmMomento;
	
	private AudioSource m_audioSource;
	private int m_currentState = 0;
	private bool m_canPress;

	void Start () {
		EvaluateState(m_currentState);
		m_audioSource = GetComponent<AudioSource>();
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
				StartCoroutine(RenderPlace("13 de Setembro de 2023\nFaculdade"));
			break;
			case 1:
				WriteText.instance.ActivatedProfessor(true);
				StartCoroutine(RenderDialog("Damires? Voce faz aula comigo??"));
			break;
			case 2:	
				WriteText.instance.ActivateDamires(true);
				WriteText.instance.ActivatedProfessor(false);
				StartCoroutine(RenderDialog("Faaala PROFESSOR! Tudo em cima? Meu bacano, meu consagrado, meu engradado."));
			break;
			case 3:	
				WriteText.instance.ActivateDamires(false);
				WriteText.instance.ActivatedProfessor(true);
				StartCoroutine(RenderDialog("Essa atitute desleixada... Esse olhar fundo e sem esperancas... Esse cheiro de cachorro molhado... Voce veio atras de pontos ne?"));
			break;
			case 4:
				WriteText.instance.ActivateDamires(true);
				WriteText.instance.ActivatedProfessor(false);
				StartCoroutine(RenderDialog("Que nada professor, so estou um pouco curiosa, sabe, normalmente o sistema arredonda quando voce tira 59, ne?"));
			break;
			case 5:
				WriteText.instance.ActivateDamires(false);
				WriteText.instance.ActivatedProfessor(true);
				StartCoroutine(RenderDialog("Sim, senhora Damires, esta certissima."));
			break;
			case 6:
				WriteText.instance.ActivateDamires();
				WriteText.instance.ActivatedProfessor(false);
				StartCoroutine(RenderDialog("Entao por que motivo minha nota nao veio como 60?"));
			break;
			case 7:
				WriteText.instance.ActivateDamires(false);
				WriteText.instance.ActivatedProfessor(true);
				StartCoroutine(RenderDialog("Bom, e que eu nao gosto de voce."));
			break;
			case 8:
				WriteText.instance.ActivateDamires();
				WriteText.instance.ActivatedProfessor(false);
				StartCoroutine(RenderDialog("Raios."));
			break;
			case 9:
				WriteText.instance.ActivateDamires(false);
				WriteText.instance.ActivatedProfessor(true);
				StartCoroutine(RenderDialog("Mas ha uma maneira de voce passar sem reprovar pela quinta vez Damires."));
			break;
			case 10:
				WriteText.instance.ActivateDamires();
				WriteText.instance.ActivatedProfessor(false);
				StartCoroutine(RenderDialog("Nossa professor, nao sabia que seu tipo eram fracassadas e depressivas."));
			break;
			case 11:
				WriteText.instance.ActivateDamires(false);
				WriteText.instance.ActivatedProfessor(true);
				Camera.main.GetComponent<Screenshake>().ShakeScreen(0.1f);
				m_audioSource.PlayOneShot(objectionAudio);
				StartCoroutine(RenderDialog("QUEE?"));
			break;
			case 12:
				StartCoroutine(RenderDialog("Nao! Credo! Temos um problema aqui na faculdade."));
			break;
			case 13:
				WriteText.instance.ActivateDamires();
				WriteText.instance.ActivatedProfessor(false);
				StartCoroutine(RenderDialog("Os servidores tao de greve ou nao tem agua gelada nos bebedouros? Pois isso e bem normal professor."));
			break;
			case 14:
				WriteText.instance.ActivateDamires(false);
				WriteText.instance.ActivatedProfessor(true);
				StartCoroutine(RenderDialog("Nao Damires, um aluno que seria avaliado no TCC surtou e transformou geral em galinhas!"));
			break;
			case 15:
				WriteText.instance.ActivateDamires();
				WriteText.instance.ActivatedProfessor(false);
				Camera.main.GetComponent<Screenshake>().ShakeScreen(0.1f);
				m_audioSource.PlayOneShot(audioUmMomento);
				StartCoroutine(RenderDialog("O QUEEEE, como assim?"));
			break;
			case 16:
				WriteText.instance.ActivateDamires(false);
				WriteText.instance.ActivatedProfessor(true);
				StartCoroutine(RenderDialog("Veja bem, sabe o Enzo da Bioengenharia?"));
			break;
			case 17:
				WriteText.instance.ActivateDamires(true);
				WriteText.instance.ActivatedProfessor(false);
				StartCoroutine(RenderDialog("Qual Enzo? O da turma 13? 14? 15? Ou um dos 4 da 16?"));
			break;
			case 18:
				WriteText.instance.ActivateDamires(false);
				WriteText.instance.ActivatedProfessor(true);
				StartCoroutine(RenderDialog("Certamente o da turma 13, ele foi fazer a apresentacao do TCC dele sobre mutacoes geneticas. O trabalho estava magnifico!"));
			break;
			case 19:
				StartCoroutine(RenderDialog("Pena que a fonte dele estava com tamanho 12,01... A ABNT nao perdoa mesmo..."));
			break;
			case 20:
				WriteText.instance.ActivateDamires(true);
				WriteText.instance.ActivatedProfessor(false);
				StartCoroutine(RenderDialog("Se eu tivesse na posicao dele teria feito algo pior... mas entao professor, o que tu quer que eu faca?"));
			break;
			case 21:
				WriteText.instance.ActivateDamires(false);
				WriteText.instance.ActivatedProfessor(true);
				StartCoroutine(RenderDialog("Bom, preciso que voce destrua todos os ovos contaminados nos blocos da nossa faculdade!"));
			break;
			case 22:
				StartCoroutine(RenderDialog("Para isso vou te dar uma injecao que vai lhe dar a habilidade de usar vinhas de arvores para acabar com eles."));
			break;
			case 23:
				WriteText.instance.ActivateDamires(true);
				WriteText.instance.ActivatedProfessor(false);
				StartCoroutine(RenderDialog("Eu nao to nem ligando... so quero meus pontos - os fins justificam os meios, nao era isso que Einstein dizia?"));
			break;
			case 24:
				WriteText.instance.ActivateDamires(false);
				WriteText.instance.ActivatedProfessor(true);
				StartCoroutine(RenderDialog("Er... Sim... Claro... So lembre-se de nao atacar as galinhas, elas sao pessoas, evite-as."));
			break;
			case 25:
				WriteText.instance.ActivateDamires(true);
				WriteText.instance.ActivatedProfessor(false);
				StartCoroutine(RenderDialog("Beleza professor! Eu juro que nao vou te desapontar pela quinta vez."));
			break;
			case 26:
				SceneManager.LoadScene("NovaScene");
			break;
			default:
				WriteText.instance.ActivatePanels(false, false);
			break;
		}
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
