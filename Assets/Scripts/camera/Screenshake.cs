using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour {

	public float screenShakeDecay = .5f;
	private Vector3 m_screenShake;
	private float m_screenShakeAmount;

	void Update () {
		if(m_screenShakeAmount > 0) {
			float t_x = Random.Range(-m_screenShakeAmount, m_screenShakeAmount);
			float t_y = Random.Range(-m_screenShakeAmount, m_screenShakeAmount);
			m_screenShake = new Vector3(t_x,
										t_y,
										0f);
			m_screenShakeAmount -= Time.deltaTime * screenShakeDecay;
		} else {
			m_screenShake = Vector3.zero;
			transform.position = new Vector3(0f, 0f, -10f);
		}

		transform.position += m_screenShake;
	}

	public void ShakeScreen(float toShake) {
		m_screenShakeAmount = toShake;
	}
}