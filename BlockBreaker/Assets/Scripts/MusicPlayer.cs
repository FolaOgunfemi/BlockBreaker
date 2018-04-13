using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls Music Player

//OBJECTIVE: Continue Music through all of the Scene Loads. We will use a singleton to make sure that there can only be one music player existing at any given time
public class MusicPlayer : MonoBehaviour {
	
	static MusicPlayer instance = null;

	void Awake () {
		//We will keep track of when this stage is called with a unique ID, that way we know when Awake, Start etc are called
		Debug.Log ("Music Player Awake " + GetInstanceID());

		///We use GameObject.DontDestroyOnLoad (gameObject) to PRESERVE trhe music player and make it consistent. NOTE: Without the conditional below, a new music player will be added every time the player returns to Start

		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate Music Player Self-Destructing!");

		} else {

			instance = this;   ///Update Instance to the current instance on each Start

			GameObject.DontDestroyOnLoad (gameObject);   //Preserves this Game Object when the next scene is loaded. 
		}
	}

	void Start () {
		     //We will keep track of when this stage is called with a unique ID, that way we know when Awake, Start etc are called
		Debug.Log ("Music Player Start " + GetInstanceID());
											
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
