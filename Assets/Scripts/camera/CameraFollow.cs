using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	private BoxCollider2D cameraBox;//box colider of the camera
	private Transform player;//position of the player
	// Use this for initialization
	void Start () {
		cameraBox = GetComponent<BoxCollider2D>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		AspectRatioBoxChange ();
		
	}
	void FixedUpdate(){
		FollowPlayer ();
	}
	void AspectRatioBoxChange(){
		
		
	}
	void FollowPlayer(){
		if (GameObject.Find ("Boundary")) {
			BoxCollider2D boundary = GameObject.Find ("Boundary").GetComponent<BoxCollider2D>();
			transform.position = new Vector3(Mathf.Clamp(player.position.x,boundary.bounds.min.x + cameraBox.size.x/2, boundary.bounds.max.x - cameraBox.size.x/2),
			                                 Mathf.Clamp(player.position.y,boundary.bounds.min.y + cameraBox.size.y/2, boundary.bounds.max.y - cameraBox.size.y/2),
			                                 transform.position.z);
		}
		
	}
}