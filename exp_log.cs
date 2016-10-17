using UnityEngine;
using System.Collections;
using System; // for DateTime function

// System.Text and System.IO are required for creating a CSV-file 
using System.Collections.Generic;
using System.Text;
using System.IO;

public class exp_log : MonoBehaviour {

	public static string name_of_log_file;  // log file's name 

	// To declare variables of Log
	public static string exp_event; // A string variable indicating the events
	public static double exp_elapsed_time;	// A double variable for experiment elapsed time
	public static int trial_number; // An int variable indicating the number of trials
	public static string responded_target; // 
	public static double rt; // 
	// Time when the experiment started 
	public static DateTime exp_starting_time;
	// Time when a game or bait was responded
	public static DateTime responded_time;

	public static string temp_data_row; // string object

	public static List<string[]> data_row = new List<string[]>(); // list object
	public static StringBuilder data_array = new StringBuilder(); // stringbuilder object


	// Use this for initialization
	void Start () {

		exp_event = "experiment initiated ";
		trial_number = 1;

		// name expeirment log after the time the experiment started
		exp_starting_time = DateTime.Now; 
		name_of_log_file = exp_starting_time.ToString ("MM_dd_HH_mm"); // log file's name is the starting time

		// delcare a one-dimension string object to contain data
		// assign the first row (column title)
		string[] temp_data_row = new string[5]; // a temporary string container of 5 columns
		temp_data_row[0] = "experiment_event";
		temp_data_row[1] = "elapsed_time";
		temp_data_row[2] = "trial_number";
		temp_data_row[3] = "responded_target";
		temp_data_row[4] = "response_time";
		// Add a row (title) in data_row(list object) 
		data_row.Add(temp_data_row);

		// show all data in data_row
		for (int row_index = 1; row_index < data_row.Count; row_index++) {

			foreach (string item in data_row[row_index]) {
				Debug.Log (item);
			}
		}

		// To declare a jagged array fitting the length of data_row
		string[][] data_row_to_array = new string[data_row.Count][]; 

		// transfer data in data_row to array
		for (int i = 0; i < data_row_to_array.Length; i++) {
			data_row_to_array [i] = data_row [i];
		}
		Debug.Log ("data_row_to_array's length " + data_row_to_array.Length);

		for (int array_index = 0; array_index <  data_row_to_array.Length; array_index++) {
			Debug.Log ("array index: " + array_index);

			Debug.Log(string.Join (",", data_row_to_array[array_index]));
			string temp_trial_log = string.Join (",", data_row_to_array [array_index]); // Adding , to data

			data_array.AppendLine (temp_trial_log); // To write data to StringBuilder

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// write a new row of data to data_row
	public static void write_data_row(){
		
		// elapsed time calculation
		TimeSpan duration = DateTime.Now - exp_starting_time;

		// To translate rt from timespan variable to a double variable in millisecond
		exp_elapsed_time =  duration.TotalMilliseconds; 

		// 
		string[] temp_data_row = new string[5];
		temp_data_row[0] = exp_event;
		temp_data_row[1] = Convert.ToString(exp_elapsed_time); // "" was added to transform numbers to string
		temp_data_row[2] = Convert.ToString(trial_number);
		temp_data_row[3] = responded_target;
		temp_data_row[4] = Convert.ToString(rt);

		// To  erase the remaining data_row by declaring a new List vriable 
		data_row = new List<string[]>(); 

		// To write the trial's log on the list variable
		data_row.Add(temp_data_row);

		// show all data in data_row
		for (int row_index = 1; row_index < data_row.Count; row_index++) {

			foreach (string item in data_row[row_index]) {
				Debug.Log (item);
			}
		}

		// To declare a jagged array fitting the length of data_row
		string[][] data_row_to_array = new string[data_row.Count][]; 

		// transfer data in data_row to array
		for (int i = 0; i < data_row_to_array.Length; i++) {
			data_row_to_array [i] = data_row [i];
		}
		Debug.Log ("data_row_to_array's length " + data_row_to_array.Length);

		for (int array_index = 0; array_index <  data_row_to_array.Length; array_index++) {

			Debug.Log(string.Join (",", data_row_to_array[array_index]));
			string temp_trial_log = string.Join (",", data_row_to_array [array_index]); // Adding , to data

			data_array.AppendLine (temp_trial_log); // To write data to StringBuilder

		}
			
		// Debug.Log (data_array); // To show content of data_array in console
		// testing save lgo as csv
		savelogascsv();

	}

	public static void savelogascsv(){ // save experiment log as a CSV file
		string file_path = @"Assets/"+ name_of_log_file + ".csv"; // where log file will be saved
		File.WriteAllText(file_path , data_array.ToString());

	}
}
