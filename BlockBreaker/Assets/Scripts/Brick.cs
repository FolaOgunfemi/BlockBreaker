using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	private int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable; 

	public GameObject smoke;
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;  //NOTE: static variables are not exposed in inspector, even if public.Static is class-level, not object level. This is because the value would be the same across all objects

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable"); //Tracking breakable bricks

		if (isBreakable) {
			breakableCount++;
					//print (breakableCount);

		}

		timesHit = 0;

		levelManager= GameObject.FindObjectOfType<LevelManager> ();

	}
	
	// Update is called once per frame
	void Update () {
	}

	/// Can use OnCollisionEnter as well but if things move too quickly, the brick may be destroyed before the physics are enacted on the ball to make it bounce back down, resulting in the ball passing right through the brick
		void OnCollisionExit2D (Collision2D col) {
		AudioSource.PlayClipAtPoint (crack, transform.position); //play crack at position of brick

		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits (){
		

		timesHit++;


		maxHits = hitSprites.Length + 1;   //There  is a sprite for each stage of damage on a block. If a block has 2 hitSprites attached, and we add that to the original undamaged sprite, that makes three hits that it can take before it is destroyed

		if (timesHit >= maxHits) {   //We used >= instead of == just in case we make a superball that counts for 2 in the future
			breakableCount--; //remove brick from count of total bricks
					//print (breakableCount);
			Debug.Log(breakableCount);
			levelManager.BrickDestroyed();

			GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;//Instantiate smoke at the location of the brick withj default rotation

			ParticleSystem.MainModule smokePuffSystem = smokePuff.GetComponent<ParticleSystem>().main;

			smokePuffSystem.startColor = gameObject.GetComponent<SpriteRenderer> ().color; //set smokepuff color to brick color

			Destroy (gameObject); //NOTE: use "GameObject", not "this". .."this" refers to the entire brick and everything associated with it, while gameobject refers to the object in the scene
		} else {
			LoadSprites ();
		}


	}

	void LoadSprites (){
		int spriteIndex = timesHit - 1; //Load index of Sprite array 

		if (hitSprites [spriteIndex]) {   //this checks to make sure that someone has a Sprite inserted in the editor in that element. We do this to make sure that damaged blocks don't show-up as invisible when they're hit and a sprite is missing.

			//TODO complete sprite assignment
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex]; //Access the curent brick's sprite renderer and sets the sprite of that brick equal to hitSprites[spriteIndex]
		} else { 
			Debug.LogError ("There is a Sprite Missing!");
		}
	}

	// TODO Remove when winning is possible in the game
	void SimulateWin () {
		
		levelManager.LoadNextLevel ();
	}
}
