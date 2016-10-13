using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System; // for DateTime function
public class stimuli_instantiation : MonoBehaviour {

	static public DateTime timing_stimuli_presented; // timing_stimui_presented were designated to be used by Click.cs (to calculate RT)
	public GameObject game;
	public GameObject bait;

	// Use this for initialization
	void Start () {
		// declare an empty game object to containe game and baits 
		GameObject box_of_game_baits= new GameObject ("box_of_game_baits");

		string game_to_be = "red_game"; // To assign the name of the game to be loaded

		string bait_to_be = "white_bait"; // To assign the name of the bait to be loaded

		// To load the bait
		 bait = Resources.Load (bait_to_be, typeof(GameObject)) as GameObject;
		// To load the game
		 game = Resources.Load (game_to_be, typeof(GameObject)) as GameObject;

		// To declare the length of stimuli matrix
		int numer_of_x = 7;
		int numer_of_y = 7;

		// To set the zero point of stimuli array on screen
		int[,] zeroing_point = new int[,] { {-12, 7} };

		// Set-up Bait location
		//int[ , ] stimuli_matrix = new int [ , ] { {0, 0}, {1, 2}, {3, 4}, {5, 6}, {7, 8} };

		for (int x_bait = 1; x_bait < numer_of_x; x_bait ++) {
			for (int y_bait = 1; y_bait < numer_of_y; y_bait ++) {
			
				// To determine where to present the stimulus
				Vector3 stimulus_position = new Vector3 (zeroing_point [0, 0] + 4 * x_bait, zeroing_point [0, 1] + 3 * y_bait, 11);

				// To instantiate the stimulus
				GameObject cloned_bait = Instantiate (bait , stimulus_position, Quaternion.identity) as GameObject;

				// To change the name of instantiated bait:
				cloned_bait.name = "bait at " + Convert.ToString(x_bait) + " " + Convert.ToString(y_bait);

				// To assign the stimulus a child of box of game and baits
				cloned_bait.transform.parent = box_of_game_baits.transform;


			}
		}

		// To instantiate the game
		GameObject cloned_game = Instantiate (game, new Vector3 (-8, 10, 11), Quaternion.identity) as GameObject;

		// To change the name of instantiated bait:
		cloned_game.name = "game"; // codes prepared for game's coordinates: + Convert.ToString(x_bait) + " " + Convert.ToString(y_bait);


		// 
		cloned_game.transform.parent = box_of_game_baits.transform;
		Debug.Log ("instantiated game and baits in box of game and baits");

		// Mark the time when stimuli were all presented
		timing_stimuli_presented = DateTime.Now; 

	}
	// Update is called once per frame
	void Update () {

	}
}
