using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// /// BEST PRACTICE: WE FETCH THE MOUSE POSITION DIVIDED BY SCREEN WIDTH SO THAT WE CAN HAVE A RELATIVE POSITION TO REFERENCE FOR THE MOUSE POSITION. 
        //WE THEN MULTIPLY THAT BY THE WIDTH OF THE GAME WORLD (16) TO GET A NICE NEAT REPRESENTATION OF THE POSITION OF THE PADDLE IN GAME WORLD UNITS

public class Paddle : MonoBehaviour {
	public bool autoPlayMode = false;
	private Ball ball;
	public float leftBoarderX = -0.5f;
	public float rightBoarderX = 15.5f;
		

	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		//print(ball);
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlayMode) {
			moveWithMouse ();
		} else {
			autoPlay (); //insert autoplay logic
		}

	}

	void autoPlay () { //after script has found ball(void Start) map the paddle to the "y" position of the ball in order to play game automatically
		
		Vector3 ballPos = ball.transform.position;

		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);   //We are choosiung to keep the current "y" coordinate from the scene

		paddlePos.x = Mathf.Clamp(ballPos.x, leftBoarderX, rightBoarderX);  //Make paddle pos equal to ball pos
		//prevent paddle pos from exceeding world space using Clamp

		this.transform.position = paddlePos;
	}






	void moveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);   //We are choosiung to keep the current "y" coordinate from the scene

		float mousePosInWorldBlocks = Input.mousePosition.x / Screen.width * 16; //MUST be a float b/c we will be manipulatng transform.position which is a Vector3 (3 floating point coordinates in one value)
		//	print (mousePosInWorldBlocks);

		paddlePos.x = Mathf.Clamp(mousePosInWorldBlocks, -0.5f, 15.5f);  //Make mouse pos equal to paddle
		//prevent paddle pos from exceeding world space using Clamp



		this.transform.position = paddlePos; //"this" always refers to current instance of the script and attatched object


	}
}
