using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class game : MonoBehaviour {

	public string currentLoc;
	public string screen;
	private bool gameStart;
	public bool newspaper;
	public string newspaperLoc;

	public string north;
	public string south;
	public string east;
	public string west;

	//places
	private string a0;
	private string a1;
	private string a2;
	private string a3;
	private string a4;
	private string a5;
	private string a6;
	private string a7;
	private string a8;
	private string a9;
	private string a10;
	private string a11;
	private string a12;
	private string a13;

	//deathcounter
	private bool a11first;
	private bool a11second;
	private bool a12first;
	private bool a12second;
	private bool a13first;
	private bool a13second;

	//dead?
	private bool dead;

	// Use this for initialization
	void Start () {
		screen = "the adventure of sweet newspaper-doge.\n\npress spacebar to play";
		gameStart = false;
		newspaper = false;
		north = "nil";
		south = "nil";
		east = "nil";
		west = "nil";
		
		//rooms
		a0 = "nil";
		a1 = "ball pit";
		a2 = "bird nest";
		a3 = "familiar road";
		a4 = "pile of bones";
		a5 = "smelly place";
		a6 = "playground";
		a7 = "lumby castle";
		a8 = "lonely tree";
		a9 = "doge house";
		a10 = "winning place";
		a11 = "angry Diego's mansion";
		a12 = "Spooky Skeleton Swamp";
		a13 = "Unlucky Wizard Daniel";

		newspaperLoc = a4;

		a11first = true;
		a11second = false;
		a12first = true;
		a12second = false;
		a13first = true;
		a13second = false;
		dead = false;

	}
	
	// Update is called once per frame
	void Update () {

		//game start screen. spacebar to start game.
		if (Input.GetKeyDown(KeyCode.Space) && !gameStart){
			gameStart = true;
			currentLoc = a9;
			screen = "You are now at "+currentLoc;
			Move();
			Dig();
		}

		if (currentLoc == a1){
			screen = "You are now at "+currentLoc;
			Move();
			north = a11;
			south = a8;
			east = a2;
			west = a0;
			Dig();
		}

		if (currentLoc == a2){
			screen = "You are now at "+currentLoc;
			Move();
			north = a0;
			south = a9;
			east = a3;
			west = a1;
			Dig();
		}

		if (currentLoc == a3){
			screen = "You are now at "+currentLoc;
			Move();
			north = a0;
			south = a4;
			east = a10;
			west = a2;
			Dig();
		}

		if (currentLoc == a4){
			screen = "You are now at "+currentLoc;
			Move();
			north = a3;
			south = a5;
			east = a0;
			west = a9;
			Dig();
		}

		if (currentLoc == a5){
			screen = "You are now at "+currentLoc;
			Move();
			north = a4;
			south = a13;
			east = a0;
			west = a6;
			Dig();
		}

		if (currentLoc == a6){
			screen = "You are now at "+currentLoc;
			Move();
			north = a9;
			south = a0;
			east = a5;
			west = a7;
			Dig();
		}

		if (currentLoc == a7){
			screen = "You are now at "+currentLoc;
			Move();
			north = a8;
			south = a0;
			east = a6;
			west = a12;
			Dig();
		}

		if (currentLoc == a8){
			screen = "You are now at "+currentLoc;
			Move();
			north = a1;
			south = a7;
			east = a9;
			west = a0;
			Dig();
		}

		if (currentLoc == a9){
			screen = "You are now at "+currentLoc;
			Move();
			north = a2;
			south = a6;
			east = a4;
			west = a8;
			Dig();
		}

		if (currentLoc == a10){
			screen = "You are now at "+currentLoc;
			Move();
			north = a0;
			south = a0;
			east = a0;
			west = a3;
			Dig();
			if(newspaper){
				screen = "The wise old man finds that you have the magic newspaper. He finds you worthy and asks that you destroy all evil in the land. Search for the Bone of Light and fulfill your duty!";
			}
		}

		if (currentLoc == a11){
			screen = "You are now at "+currentLoc;
			if(a11first){
				screen += "\n\nDiego: 'Away! You filthy dog! Do not return!'";
				if(Input.GetKeyDown(KeyCode.DownArrow)){
				a11first = false;
				}
			}
			if(a11second && !a11first){
				screen += "\n\nDiego: 'How dare you come back!? This is the end of you!' -- YOU DIED";
				dead = true;
			}
			Move();
			north = a0;
			south = a1;
			east = a0;
			west = a0;
			Dig();
		}

		if (currentLoc == a12){
			screen = "You are now at "+currentLoc;
			if(a12first){
				screen += "\n\nYou attract the attention of spooky skeletons. Beware...";
				if(Input.GetKeyDown(KeyCode.RightArrow)){
				a12first = false;
				}
			}
			if(a12second && !a12first){
				screen += "\n\nSpooky skeletons maul you now. YOU DIED";
				dead = true;
			}
			Move();
			north = a0;
			south = a0;
			east = a7;
			west = a0;
			Dig();
		}

		if (currentLoc == a13){
			screen = "You are now at "+currentLoc;
			if(a13first){
				screen += "\n\nDaniel: 'Wha- What are you doing here, little dog? Please leave me alone...'";
				if(Input.GetKeyDown(KeyCode.UpArrow)){
				a13first = false;
				}
			}
			if(a13second && !a13first){
				screen += "\n\nDaniel: 'Unlucky...' -- YOU DIED";
				dead = true;
			}
			Move();
			north = a5;
			south = a0;
			east = a0;
			west = a0;
			Dig();
		}

		if(currentLoc != a11 && !a11first){
			a11second = true;
		}

		if(currentLoc != a12 && !a12first){
			a12second = true;
		}

		if(currentLoc != a13 && !a13first){
			a13second = true;
		}

		if(dead){
			screen += "\n\nGAME OVER. Press F to restart.";
			if(Input.GetKeyDown(KeyCode.F)){
				currentLoc = "nil";
				screen = "the adventure of sweet newspaper-doge.\n\npress spacebar to play";
				gameStart = false;
				newspaper = false;
				north = "nil";
				south = "nil";
				east = "nil";
				west = "nil";

				newspaperLoc = a4;

				a11first = true;
				a11second = false;
				a12first = true;
				a12second = false;
				a13first = true;
				a13second = false;
				dead = false;

			}
		}

		
		
	
		//function to variable to update text
		GetComponent<Text>().text = screen;
	}

	void Move () {
		if (Input.GetKeyDown(KeyCode.UpArrow) && !dead){
			if(north != a0){
			currentLoc = north;
			}
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) && !dead){
			if(south != a0){
			currentLoc = south;
			}
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) && !dead){
			if(east != a0){
			currentLoc = east;
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) && !dead){
			if(west != a0){
			currentLoc = west;
			}
		}
		if(!dead){
		screen += "\n\nUse arrow keys to move around.";
		}
	}

	void Dig () {
		if(!dead){
		screen += "\n\nPress D to dig";
		}
		if(Input.GetKeyDown(KeyCode.D) && newspaperLoc == currentLoc && !dead){
			newspaper = true;
			
		}
	}

}
