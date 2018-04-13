using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;  //Make public if we want to use Unity Editor to drag and drop

	///CHOICE: OnTriggerEnter VS OnCollisionEnter
	   /// Can choose whether to make the ball collide with a Lose Collider that is a trigger as well or a Lose Collider that is not a Trigger(meaning it is affected by physics)
	      // / If "Is Trigger" is checked, OnTriggerEnter2D will be called, otherwise, OnCollissionEnter2D will be called.

	void OnTriggerEnter2D (Collider2D trigger) {

		levelManager = GameObject.FindObjectOfType <LevelManager>(); //We could link the levelManager instance to the LoseCollider in the Unity Editor, but then we would need to drag and drop the paddle instance into the ball for each scene
		//Using generics<> to specify that it should only look through LevelManager objects

		levelManager.LoadLevel ("Lose Screen");
	}

	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision");

		levelManager.LoadLevel ("Lose Screen");
	}
}
