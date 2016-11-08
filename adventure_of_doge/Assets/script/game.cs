using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class game : MonoBehaviour {

	public string currentLoc;
	public string screen;
	private bool gameStart;
	public bool newspaper;
	public string newspaperLoc;
	public string boneLoc;

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

	//dug
	private bool justDug;
	
	//delivered
	private bool delivered;
	private bool bone;

	//evil destroyed
	private bool a11destroyed;
	private bool a12destroyed;
	private bool a13destroyed;
	private bool evildestroyed;

	// Use this for initialization
	void Start () {
		screen = "The Adventure of Sweet Doge.\n\npress spacebar to play";
		gameStart = false;
		newspaper = false;
		north = "nil";
		south = "nil";
		east = "nil";
		west = "nil";
		
		//rooms
		a0 = "nil";
		a1 = "Ball Pit";
		a2 = "Bird's Nest";
		a3 = "a familiar road";
		a4 = "a pile of bones";
		a5 = "smelly place";
		a6 = "Playground";
		a7 = "Lumby Castle";
		a8 = "a lonely tree";
		a9 = "the Doge House";
		a10 = "the Wise Old Man's house";
		a11 = "Angry Diego's mansion";
		a12 = "Spooky Skeleton Swamp";
		a13 = "Unlucky Wizard Daniel";

		newspaperLoc = a4;
		boneLoc = a7;

		a11first = true;
		a11second = false;
		a12first = true;
		a12second = false;
		a13first = true;
		a13second = false;
		dead = false;

		justDug = false;

		delivered = false;

		a11destroyed = false;
		a12destroyed = false;
		a13destroyed = false;

		evildestroyed = false;



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
			if(newspaper){
				screen = "You return to the Wise Old Man's house. The Wise Old Man finds that you have the magic newspaper. He finds you worthy and asks that you destroy all evil in the land. Search for the Bone of Light and fulfill your duty!";
				delivered = true;
				if(Input.GetKeyDown(KeyCode.LeftArrow)){
					newspaper = false;
				}
			}
			if(!newspaper && !delivered){
				screen += "\n\nWise Old Man: 'Oh sweet doge, come visit me when you have found something...'";
			}
			if(delivered && !newspaper && !bone){
				screen += "\n\nWise Old Man: 'Oh sweet doge, go on and find the Bone of Light. You must destroy all evil. Please.'";
			}
			if(delivered && !newspaper && bone && !evildestroyed){
				screen += "\n\nWise Old Man: 'Oh sweet doge, you found the Bone of Light. You know what you must do now.'";
			}
			if(evildestroyed){
				screen = "You return to the Wise Old Man's house... but he is missing at this moment.\n\nWhat's also missing is the rest of this 'story.' The man must have fled with it!";
			}
			Move();
			north = a0;
			south = a0;
			east = a0;
			west = a3;
			Dig();
		}

		if (currentLoc == a11){
			screen = "You are now at "+currentLoc;
			if(!bone){
			if(a11first){
				screen += "\n\nDiego: 'Away! You filthy doge! Do not return!'";
				if(Input.GetKeyDown(KeyCode.DownArrow)){
				a11first = false;
				}
			}
			if(a11second && !a11first){
				screen += "\n\nDiego: 'How dare you come back!? This is the end of you, foolish doge!' -- YOU DIED";
				dead = true;
			}}
			if(bone && !a11destroyed){
				screen += "\n\nDiego: 'The bone.. No! This can't be happening!'";
				if(Input.GetKeyDown(KeyCode.E)){
					a11destroyed = true;
				}
			}
			if(a11destroyed){
				screen += "\n\nYou use the Bone of Light and silence Diego.";
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
			if(!bone){
			if(a12first){
				screen += "\n\nYou attract the attention of spooky skeletons. Beware...";
				if(Input.GetKeyDown(KeyCode.RightArrow)){
				a12first = false;
				}
			}
			if(a12second && !a12first){
				screen += "\n\nSpooky skeletons maul you now. YOU DIED";
				dead = true;
			}}
			if(bone && !a12destroyed){
				screen += "\n\nThe skeletons sense the Bone's presence and kneel before you.";
				if(Input.GetKeyDown(KeyCode.E)){
					a12destroyed = true;
				}
			}
			if(a12destroyed){
				screen += "\n\nThe skeletons crumble.";
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
			if(!bone){
			if(a13first){
				screen += "\n\nDaniel: 'Wha- What are you doing here, little doge? Please leave me alone...'";
				if(Input.GetKeyDown(KeyCode.UpArrow)){
				a13first = false;
				}
			}
			if(a13second && !a13first){
				screen += "\n\nDaniel: 'Unlucky...' -- YOU DIED";
				dead = true;
			}}
			if(bone && !a13destroyed){
				screen += "\n\nDaniel: 'The bone.. How can I be THIS unlucky!?!'";
				if(Input.GetKeyDown(KeyCode.E)){
					a13destroyed = true;
				}
			}
			if(a13destroyed){
				screen += "\n\nDaniel disintegrates...";
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

		if(bone){
			screen += "\n\nPress E to use the Bone of Light!";
		}

		if(dead){
			screen += "\n\nGAME OVER. Press F to restart.";
			if(Input.GetKeyDown(KeyCode.F)){
				currentLoc = "nil";
				screen = "The Adventure of Sweet Doge.\n\npress spacebar to play";
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
				justDug = false;
				delivered = false;
				bone = false;

				a11destroyed = false;
				a12destroyed = false;
				a13destroyed = false;
				evildestroyed = false;

			}
		}

		if(a11destroyed && a12destroyed && a13destroyed){
			evildestroyed = true;
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
		if(Input.GetKeyDown(KeyCode.D) && (!newspaper || (delivered && !bone))){
			justDug = true;
		}
		if(!delivered && Input.GetKeyDown(KeyCode.D) && newspaperLoc == currentLoc && !dead){
			newspaper = true;
		}
		if(!delivered && newspaper && justDug && newspaperLoc == currentLoc){
			screen += "\n\nYou dig up a magical newspaper! Where should the newspaper be delivered to?";
			if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
				justDug = false;
			}
		}
		if(!newspaper && justDug && !bone){
			if(currentLoc != a10){
				screen += "\n\nYou dig but find nothing here";
			}
			if(currentLoc == a10){
				screen += "\n\nWise Old Man: Oi! You can't dig here!!!";
			}
			if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
				justDug = false;
			}
		}
		if(newspaper && !dead && !delivered){
			screen += "\n\nObjective: Deliver the magic newspaper.";
		}
		if(!dead && !justDug && !bone && !newspaper){
		screen += "\n\nPress D to dig";
		}

		if(Input.GetKeyDown(KeyCode.D) && boneLoc == currentLoc && !dead && delivered){
			bone = true;
		}

		if(delivered && !dead && !bone){
			screen += "\n\nObjective: Find the Bone of Light";
		}
		if(delivered && bone && justDug && boneLoc == currentLoc){
			screen += "\n\nYou dig up the Bone of Light. Now destroy all evil!";
			if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
				justDug = false;
			}
		}
		if(delivered && bone && !evildestroyed){
			screen += "\n\nObjective: Destroy all evil";
		}
		if(delivered && bone && evildestroyed && currentLoc != a10){
			screen += "\n\nObjective: Return to the Wise Old Man";
		}
	}

}
