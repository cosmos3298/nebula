using UnityEngine;
using System.Collections;

public class exp_starter : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
//		if (exp_log.trial_number < total_trial_number) {
//			stimuli_instantiation.exp_initiator ();
//		}
	}

	public static void exp_start(int total_trial_number, int starting_trial_number){
	
		/* To assign the starting_trial_number, which could be 0 or any number desired
		 * to allow experimenters to insert break and illustration between experiment conditions or sessions.
		*/
		if (exp_log.trial_number <= total_trial_number){
		
			exp_log.trial_number = starting_trial_number;

		// To start the experiment 
			stimuli_instantiation.exp_initiator ();
		}
		
	}

}
