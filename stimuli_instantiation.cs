using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System; // for DateTime function
public class stimuli_instantiation : MonoBehaviour {

	// timing_stimui_presented were designated to be used to calculate RT
	static public DateTime time_stimuli_presented; 

	public static GameObject game;
	public static GameObject bait;


	public static void exp_initiator () {


		// declare an empty game object to containe game and baits 
		GameObject box_of_game_baits= new GameObject ("box_of_game_baits");

		string game_to_be = "red_game"; // To assign the name of the game
		//string bait_to_be = "white_bait"; // To assign the name of the bait to be loaded
		string[] bait_to_be = {"white_bait","green_bait"}; // To assign all names of baits (to be loaded later)

		// To declare the length of stimuli matrix
		int number_of_x = 6;
		int number_of_y = 6;

		// To declare the distance between stimuli
		int horizontal_distance = 4;
		int vertical_distance = 3;

		// To set the zero point of stimuli array on screen
		int[,] zeroing_point = new int[,] { {-10, 7} };

		// To issue a random seed using System naming space
		System.Random random_seed = new System.Random ();

		//UnityEngine.Random.seed = System.Guid.NewGuid ().GetHashCode (); // To use Guid to generate random number
		int x_rand = random_seed.Next (0,6); // To generate a random number between 0 to 5 matching later for-loop index
		Debug.Log(x_rand);

		// To refresh random seed
		random_seed = new System.Random ();

		int y_rand = random_seed.Next (0,6); // To generate a random number between 0 to 5 matching later for-loop index
		Debug.Log(y_rand);
		for (int x = 0; x < number_of_x; x ++) {
			for (int y = 0; y < number_of_y; y ++) {

				// To load the bait
		
				int bait_index = random_seed.Next (0, (bait_to_be.Length)); // To generate a random number from number of baits
				bait = Resources.Load (bait_to_be[bait_index], typeof(GameObject)) as GameObject;

				// To load the game
				game = Resources.Load (game_to_be, typeof(GameObject)) as GameObject;

				// To determine where to present the stimulus

				int x_coordinate = zeroing_point[ 0 , 0 ]+ horizontal_distance * x; // convert loop index to x with horizontal distance
				int y_coordinate = zeroing_point[ 0 , 1 ]+ vertical_distance * y; // convert loop index to y with vertical distance

				Vector3 location = new Vector3( x_coordinate, y_coordinate, 11);

				/*
				The following selection statement depicted what stimulus to be presented
				*/

				if (x == x_rand && y == y_rand) // for game
				{
					// To instantiate the game
					GameObject cloned_game = Instantiate (game, location, Quaternion.identity) as GameObject;

					// To change the name of instantiated bait:
					cloned_game.name = "game at" + Convert.ToString(x_coordinate) + " " + Convert.ToString(y_coordinate); // codes prepared for game's coordinates: + Convert.ToString(x_bait) + " " + Convert.ToString(y_bait);
					cloned_game.transform.parent = box_of_game_baits.transform;
					Debug.Log ("game at" + Convert.ToString (x_coordinate) + " " + Convert.ToString (y_coordinate));
				}

				else{ // for baits
					// To instantiate the stimulus
					GameObject cloned_bait = Instantiate (bait , location, Quaternion.identity) as GameObject;

					// To change the name of instantiated bait:
					cloned_bait.name = "bait at " + Convert.ToString(x_coordinate) + " " + Convert.ToString(y_coordinate);

					// To assign the stimulus a child of box of game and baits
					cloned_bait.transform.parent = box_of_game_baits.transform;
				//	Debug.Log ("bait at" + Convert.ToString (x_coordinate) + " " + Convert.ToString (y_coordinate));
				}

			}
		}
			

		Debug.Log ("instantiated game and baits in box of game and baits");

		// Mark the time when stimuli were all presented
		time_stimuli_presented = DateTime.Now; 

	}


	// Use this for initialization
	void Start(){
	}
	// Update is called once per frame
	void Update () {
	}
}
