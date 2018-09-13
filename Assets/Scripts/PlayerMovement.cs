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

	[Header("Jump Control")]
	public float jumpPressedRememberTime = 0.2f;
	public float groundedRememberTime = 0.2f;
	private float m_jumpPressedRemember;
	private float m_groundedRemember;
	public float cutJumpHeight = 0.5f;
	
	[Header("Move Control")]
	public float maxVelocity = 5f;
	public float horizontalDampingWhenStopping = 0.75f;
	public float horizontalDampingWhenTurning = 0.25f;
	public float horizontalDamping = 0.5f;
	public float airborneHorizontalDampingWhenStopping = 0.15f;
	public float airborneHorizontalDampingWhenTurning = 0.1f;
	public float airborneHorizontalDamping = 0.1f;

	
	void Start () {
		m_rigidbody = GetComponent<Rigidbody2D>();
		m_animator = GetComponent<Animator>();
		m_feetCollider = GetComponentInChildren<BoxCollider2D>();
		m_isAlive = true;
	}
	
	void FixedUpdate () {
		if(!m_isAlive) return;

		Run();
		Jump();
		FlipSprite();
		AnimationLogic();	
	}

	private void Run() {
		float t_movement = m_rigidbody.velocity.x;
		t_movement += Input.GetAxisRaw("Horizontal");

		if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01f) {
			if(Mathf.Abs(m_rigidbody.velocity.y) > 0) {
				t_movement *= Mathf.Pow(1f - airborneHorizontalDampingWhenStopping, Time.deltaTime * 10f);
			} else {
				t_movement *= Mathf.Pow(1f - horizontalDampingWhenStopping, Time.deltaTime * 10f);
			}
		} else if(Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(t_movement)) {
			if(Mathf.Abs(m_rigidbody.velocity.y) > 0) {
				t_movement *= Mathf.Pow(1f - airborneHorizontalDampingWhenTurning, Time.deltaTime * 10f);
			} else {
				t_movement *= Mathf.Pow(1f - horizontalDampingWhenTurning, Time.deltaTime * 10f);
			}
		} else {
			if(Mathf.Abs(m_rigidbody.velocity.y) > 0) {
				t_movement *= Mathf.Pow(1f - airborneHorizontalDamping, Time.deltaTime * 10f);
			} else {
				t_movement *= Mathf.Pow(1f - horizontalDamping, Time.deltaTime * 10f);
			}
		}

		t_movement = Mathf.Clamp(t_movement, -maxVelocity, maxVelocity);

		m_rigidbody.velocity = new Vector2(t_movement, m_rigidbody.velocity.y);
	}

	private void FlipSprite() {
		if(Mathf.Abs(m_rigidbody.velocity.x) > Mathf.Epsilon) {
			transform.localScale = new Vector2(Mathf.Sign(m_rigidbody.velocity.x), transform.localScale.y);
		}
	}

	private void AnimationLogic() {
		if(m_rigidbody.velocity.y > 0) {
			m_animator.Play("Jumping");
		} else if(Mathf.Abs(m_rigidbody.velocity.x) > Mathf.Epsilon) {
			m_animator.Play("Running");
		} else {
			m_animator.Play("Idle");
		}
	}

	private void Jump() {

		if(m_feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
			m_groundedRemember = groundedRememberTime;
		}

		m_jumpPressedRemember -= Time.fixedDeltaTime;
		m_groundedRemember -= Time.fixedDeltaTime;

		if(Input.GetKeyDown(KeyCode.Space)) {
			m_jumpPressedRemember = jumpPressedRememberTime;
		}

		if(Input.GetKeyUp(KeyCode.Space)) {
			if(m_rigidbody.velocity.y > 0) {
				m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_rigidbody.velocity.y * cutJumpHeight);
			}
		}

		if((m_jumpPressedRemember > 0) && (m_groundedRemember > 0)) {
			m_jumpPressedRemember = 0f;
			m_groundedRemember = 0f;

			Vector2 t_currentVelocity = m_rigidbody.velocity;
			t_currentVelocity.y = jumpSpeed;
			m_rigidbody.velocity = t_currentVelocity;
		}

	}
}
