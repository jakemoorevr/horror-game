using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

	public float speed = 10.0F;	
	public float sensitivity = 2f;
	public GameObject camera;
	public GameObject player;

	//Mouse movement
	float rotX;
	float rotY;

	//shrinking and growing
	public bool shrunken = false;

	// Use this for initialization
	void Start () {
		
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

		//wasd movement
		float translation = Input.GetAxis ("Vertical") * speed;
		float strafe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		strafe *= Time.deltaTime;
		transform.Translate (strafe, 0, translation);

		//Mouse looking
		rotX = Input.GetAxis("Mouse X") * sensitivity;
		rotY = Input.GetAxis("Mouse Y") * sensitivity;
		transform.Rotate (0, rotX, 0);
		camera.transform.Rotate (-rotY, 0, 0);


		transform.Translate (strafe, 0, translation);

		//Returns cursor to screen
		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;

		//Shrinks player
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!shrunken)
				shrink ();
			else
				grow ();
		} 
	}

	private void shrink() {
		
		player.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);

		print("scaling down");
		shrunken = true;
	}

	private void grow() {
		player.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		shrunken = false;
	}
}
