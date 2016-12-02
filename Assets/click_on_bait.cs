using UnityEngine;
using System.Collections;
using System;

public class click_on_bait : MonoBehaviour {
	
	// Mouse-down behavior on game
	void OnMouseDown(){

		exp_log.responded_time = DateTime.Now; 
		// To Calculate rt
		TimeSpan duration = exp_log.responded_time - stimuli_instantiation.time_stimuli_presented;
		// To translate rt from timespan variable to a double variable in millisecond
		exp_log.rt =  duration.TotalMilliseconds; 

		//Debug.Log ("original duration  = " + duration); // RT in original Timespan format
		//Debug.Log ("RT = " + exp_log.rt + " ms"); // RT in millisecond format 

		// Declare that a bait was hit
		Debug.Log (name.ToString () + " was hit");

		// experiment event 
		exp_log.exp_event = "false alarm";

		// responded target
		exp_log.responded_target = name.ToString();

		// write a new entry in log
		exp_log.write_data_row();
	}

	// Use this for initialization
	void Start () {
				
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
