using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float playerVelocity = 5f;
	public float jumpSpeed = 12f;

	private bool m_isAlive;

	private Rigidbody2D m_rigidbody;
	private Animator m_animator;
	// private BoxCollider2D m_bodyCollider;
	private BoxCollider2D m_feetCollider;

	
	void Start () {
		m_rigidbody = GetComponent<Rigidbody2D>();
		m_animator = GetComponent<Animator>();
		m_feetCollider = GetComponentInChildren<BoxCollider2D>();
		m_isAlive = true;
	}
	
	void Update () {
		if(!m_isAlive) return;

		Run();
		Jump();
		FlipSprite();
		AnimationLogic();	
	}

	private void Run() {
		float t_movement = Input.GetAxisRaw("Horizontal");
		m_rigidbody.velocity = new Vector2(t_movement * playerVelocity, m_rigidbody.velocity.y);
	}

	private void FlipSprite() {
		if(Mathf.Abs(m_rigidbody.velocity.x) > Mathf.Epsilon) {
			transform.localScale = new Vector2(Mathf.Sign(m_rigidbody.velocity.x), transform.localScale.y);
		}
	}

	private void AnimationLogic() {
		if(Mathf.Abs(m_rigidbody.velocity.x) > Mathf.Epsilon) {
			m_animator.Play("Running");
		} else {
			m_animator.Play("Idle");
		}
	}

	private void Jump() {
		if(!m_feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;

		if(Input.GetKeyDown(KeyCode.Space)) {
			m_rigidbody.velocity += new Vector2(0f, jumpSpeed);
		}
	}
}
