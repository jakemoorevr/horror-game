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
	private float actualScale = 1.0f;
	private float scaleDuration = 100;
	private float timer = 0.0f;

	private bool grown = true;
	private bool shrunk = false;
	private bool changing = false;

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

		timer += Time.deltaTime;

		//If we are grown and want to shrink
		if (!grown && shrunk && changing)
			shrink ();

		//If we are shrunk and want to grow
		if (!shrunk && grown && changing)
			grow ();

		//Set timer to 0 on spacebar and grow or shrink
		if (Input.GetKeyDown (KeyCode.Space) && !(changing)) {

			timer = 0;
			if (grown) {
				shrunk = true;
				grown = false;
				changing = true;
			} 
			else if (shrunk) {
				grown = true;
				shrunk = false;
				changing = true;
			}
		}	
	}

	private void shrink() {

		//Done shrinking
		if (actualScale < 0.1) {
			actualScale = 0.1f;
			changing = false;
		} 
		//Currently shrinking
		else if (changing) {
			player.transform.localScale = new Vector3 (actualScale, actualScale, actualScale);
			actualScale = 1 - (timer / 100 * scaleDuration);
		}
	}

	private void grow() {

		//Done growing
		if (actualScale > 1.0) {
			actualScale = 1.0f;
			changing = false;
		} 

		//Currently growing
		else if (changing) {
			player.transform.localScale = new Vector3 (actualScale, actualScale, actualScale);
			actualScale = timer / 100 * scaleDuration;
		}
	}
}
