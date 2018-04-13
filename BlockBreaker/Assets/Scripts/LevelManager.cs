using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
		Brick.breakableCount = 0; //reset breakable bricks each level
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1); //uses level index from the build settings

		Brick.breakableCount = 0; //reset breakable bricks each level
	}

	public void BrickDestroyed() { //Load the next level if the brick count reaches 0.  THIS METHOD WILL BE CALLED FROM Brick whenever a brick is destroyed.
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();


		}

	}
}
