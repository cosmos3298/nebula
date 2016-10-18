using UnityEngine;
using System.Collections;

public class exp_starter : MonoBehaviour {
	static int total_trial_number = 5;
	// Use this for initialization
	void Start () {
		
		if (exp_log.trial_number < total_trial_number) {
			stimuli_instantiation.exp_initiator ();
		}
	}

	public static void exp_start(){
		if (exp_log.trial_number <= total_trial_number) { // To start trials according to the value of total trial number
			stimuli_instantiation.exp_initiator ();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
