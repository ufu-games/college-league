using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {

	public Text fpsText;
	private int m_frameCount;
	private float m_elapsedTime;
	private double m_frameRate;
	
	void Awake() {
		
	}
	void Update () {
		m_frameCount++;
		m_elapsedTime += Time.deltaTime;
		if(m_elapsedTime > 0.5f) {
			m_frameRate = System.Math.Round(m_frameCount / m_elapsedTime, 1, System.MidpointRounding.AwayFromZero);
			m_frameCount = 0;
			m_elapsedTime = 0;
			fpsText.text = ("fps: " + m_frameRate.ToString());
		}
	}
}