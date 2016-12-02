using UnityEngine;
using System.Collections;
using System; // for DateTime function

public class click_on_game : MonoBehaviour {
	// Use this for initialization
	// 

	public static int exp_last_trial;

	void Start () {

					}

	// Mouse-down behavior on game
	void OnMouseDown(){
		
		exp_log.responded_time = DateTime.Now; 

		TimeSpan duration = exp_log.responded_time - stimuli_instantiation.time_stimuli_presented;
		exp_log.rt =  duration.TotalMilliseconds; // simplify rt as a double variable

		//Debug.Log (GameObject.FindGameObjectWithTag("experiment"));
		Debug.Log (name.ToString () + " was hit");

		// experiment event 
		exp_log.exp_event = "hit";

		// elapsed time is calculated by exp_log.write_data_row

		// responded target
		exp_log.responded_target = name.ToString();

		// write a new entry in log
		exp_log.write_data_row();

		// After Logging data of the trial

		// 1. To add trial number when game was hit
		exp_log.trial_number++;

		// 2. To find box of game and baits created by stimuli instantiation and remove all baits and game
		GameObject box_of_game_baits = GameObject.Find ("box_of_game_baits"); 	
		Destroy(box_of_game_baits);

		// 3. To start the next trial
		exp_starter.exp_start(exp_control.total_trial_number, exp_control.starting_trial_number);

	}

	// Update is called once per frame
	void Update () {
	}

}

