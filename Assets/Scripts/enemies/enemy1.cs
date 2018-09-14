using UnityEngine;
using System.Collections;

public class enemy1: MonoBehaviour{
	private Rigidbody2D rb;
	private Transform tr;
	//private Animator an;
	public Transform verificaChao;
	public Transform verificaParede;
	
	private bool estaNaParede;
	private bool estaNoChao;
	private bool virandoParaDireita;
	private bool invencivel = false;
	
	public float velocidade;
	public float raioValidaChao;
	public float raioValidaParede;
    public int vitalidade;	
	public LayerMask solido;
	
	//public GameObject gameObject;
	
	void Awake(){
		gameObject.tag = "enemy";

		vitalidade = 4;
		
		rb = GetComponent<Rigidbody2D>();
		tr = GetComponent<Transform>();
		//an = GetComponent<Animator>();
		
		virandoParaDireita = true;
	}
	
	void FixedUpdate(){
		EnemyMoviments();
		if (vitalidade <= 0){
			Destroy(gameObject);
		}
	}
	
	void EnemyMoviments(){
		
		estaNoChao = Physics2D.OverlapCircle(verificaChao.position, raioValidaChao, solido);
		estaNaParede = Physics2D.OverlapCircle(verificaParede.position, raioValidaParede, solido);
		
		if ((!estaNoChao || estaNaParede) && virandoParaDireita){
			Flip();
		}
		
		else if ((!estaNoChao || estaNaParede) && !virandoParaDireita){
			Flip();
		}
		
		if (estaNoChao){
			rb.velocity = new Vector2(velocidade, rb.velocity.y);
		}
	}
	
	void Flip(){
		virandoParaDireita = !virandoParaDireita;
		tr.localScale = new Vector2(-tr.localScale.x, tr.localScale.y);
		
		velocidade *= -1;
	}
	
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		
		Gizmos.DrawSphere(verificaChao.position, raioValidaChao);
		Gizmos.DrawSphere(verificaParede.position, raioValidaParede);
	}
	
	//void OnTriggerEnter2D(Collider2D other){
	//	if (other.gameObject.CompareTag("Bala")){
	//		vitalidade--;
	//	}
	//	if (other.gameObject.CompareTag ("Player")) {
	//		StartCoroutine(player.KnockBack(0.02f,400));
	//		player.takeDamage(1);
	//	}
	//}
	//void OnTriggerStay2D(Collider2D other) {
	//	if (other.gameObject.CompareTag ("Player")) {
	//		StartCoroutine (player.KnockBack (0.02f, 400));
	//		player.takeDamage (1);
	//	}
	//}
}
