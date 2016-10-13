using UnityEngine;
using System.Collections;
using System; // for DateTime function

public class click_on_game : MonoBehaviour {
	// Use this for initialization
	// 
	public static double rt; // if double format is not supported, float format could be adopted
	public static int exp_last_trial;
	public static GameObject log_recorder;
	void Start () {
		


					}

	// Mouse-down behavior on game
	void OnMouseDown(){
		
		DateTime current_time = DateTime.Now; 
		Debug.Log ("current time: " + current_time); // time when the game was hit

		TimeSpan duration = current_time - Convert.ToDateTime (stimuli_instantiation.timing_stimuli_presented);
		rt =  duration.TotalMilliseconds; // simplify rt as a double variable

		// duration between presentation and repsonse were calculated
		// timing_stimui_presented were determined in replicating_bait_RL.cs
		Debug.Log("RT = " + current_time + " - " +  Convert.ToDateTime (stimuli_instantiation.timing_stimuli_presented));
		//Debug.Log ("original duration  = " + duration); // RT in original Timespan format
		Debug.Log ("RT = " + rt + " ms"); // RT in millisecond format 

		// find box of game and baits created by stimuli instantiation.cs
		GameObject box_of_game_baits = GameObject.Find ("box_of_game_baits"); 

		//Debug.Log (GameObject.FindGameObjectWithTag("experiment"));
		Debug.Log (name.ToString () + " was hit");

	

	//Destroy (GameObject.FindGameObjectWithTag("experiment"));
		Destroy(box_of_game_baits);
	//white_bait.SetActive (false); 
	
	// setting progress indicator
		exp_log.trial_number++;
		//if (exp_progess ==1) {
		// when trials are over, activate script in exp_log to save experiment data in a CSV-file
		//}
		exp_log.savelogascsv();
	}

	// Update is called once per frame
	void Update () {
	}

}

