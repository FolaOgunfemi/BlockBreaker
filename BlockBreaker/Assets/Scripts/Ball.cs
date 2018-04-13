using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Paddle paddle;		 //Make public if we want to use Unity Editor to drag and drop
	private bool hasStarted = false;


	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {

		paddle = GameObject.FindObjectOfType <Paddle> ();  
								//We could link the Ball to a paddle in the Unity Editor, but then we would need to drag and drop the paddle instance into the ball for each scene
									//Using generics<> to specify that it should only look through paddle objects


		paddleToBallVector = this.transform.position - paddle.transform.position;
		//print (paddleToBallVector.y);

	}

	// Update is called once per frame
	void Update () {

		if (!hasStarted) {   //If the round hasn't started, bind the ball to the paddle and wait for a mouse click
			//Ball should sit on top of the paddle
			//Set the position of the ball equal to the position of the paddle + their initial offset
			this.transform.position = paddle.transform.position + paddleToBallVector;


			if (Input.GetMouseButtonDown (0)) {
				print ("MouseClicked, Launching Ball");
				hasStarted = true;

				//Velocity is a Vector2
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
			//We would like to add some level of randomness to the ball's bounce t prevent infinite loops
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f)); //when used, this will add random velcoity in the specified range to x, and y....we did not change z. 
			print ("randomness: " + tweak);

		if (hasStarted) {
			GetComponent<AudioSource> ().Play ();
			//The ball collides with the paddle initially, causing the boing sound to come out when the game starts. To avoid this, we write code that tells it to release the sound, only if the game has started.

			GetComponent<Rigidbody2D>().velocity += tweak;
		
		}
	}
}
