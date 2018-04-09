using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsController : MonoBehaviour {

	public float speed = 2f;
	public float sensitivity = 2f;
	public GameObject camera;
	CharacterController player;
	public bool shrunken = false;

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

		//Shrinks player
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!shrunken)
				shrink ();
			else
				grow ();
		} 
	}

	public void shrink() {
		player.radius = 0.25f;
		player.height = 1.0f;
		player.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
		shrunken = true;
	}

	public void grow() {
		player.radius = 0.5f;
		player.height = 2.0f;
		player.transform.localScale = new Vector3 (0.285f, 0.285f, 0.285f);
		shrunken = false;
	}
}
