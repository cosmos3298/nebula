using UnityEngine;
using System.Collections;
using System;

public class click_on_bait : MonoBehaviour {
	
	// Mouse-down behavior on game
	void OnMouseDown(){

		DateTime current_time = DateTime.Now; 
		Debug.Log ("current time: " + current_time); // time when the game was hit

		TimeSpan duration = current_time - Convert.ToDateTime (stimuli_instantiation.timing_stimuli_presented);
		click_on_game.rt =  duration.TotalMilliseconds; // simplify rt as a double variable

		// duration between presentation and repsonse were calculated
		// timing_stimui_presented were determined in replicating_bait_RL.cs
		Debug.Log("RT = " + current_time + " - " +  Convert.ToDateTime (stimuli_instantiation.timing_stimuli_presented));

		//Debug.Log ("original duration  = " + duration); // RT in original Timespan format
		Debug.Log ("RT = " + click_on_game.rt + " ms"); // RT in millisecond format 

		// Declare that a bait was hit
		Debug.Log (name.ToString () + " was hit");

	}

	// Use this for initialization
	void Start () {
				
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
