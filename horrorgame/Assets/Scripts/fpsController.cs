using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsController : MonoBehaviour {

	public float speed = 2f;
	public float sensitivity = 2f;
	public GameObject camera;
	CharacterController player;

	//Keyboard movement
	float moveFB;
	float moveLR;

	//Mouse movement
	float rotX;
	float rotY;

	// Use this for initialization
	void Start () {

		player = GetComponent<CharacterController> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		//Creates movement for player with wasd
		moveFB = Input.GetAxis ("Vertical") * speed;
		moveLR = Input.GetAxis ("Horizontal") * speed;

		Vector3 movement = new Vector3 (moveLR, 0,moveFB);
		movement = transform.rotation * movement;
		player.Move (movement * Time.deltaTime);

		//Mouse looking
		rotX = Input.GetAxis("Mouse X") * sensitivity;
		rotY = Input.GetAxis("Mouse Y") * sensitivity;
		transform.Rotate (0, rotX, 0);
		camera.transform.Rotate (-rotY, 0, 0);


	}
}
