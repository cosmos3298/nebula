using UnityEngine;
using System.Collections;
using System; // for DateTime function

// System.Text and System.IO are required for creating a CSV-file 
using System.Collections.Generic;
using System.Text;
using System.IO;

public class exp_log : MonoBehaviour {

	public static string name_of_log_file; // make file name public
	public static string exp_progess; // An variable indicating the progress of experiment
	public static int trial_number; // An variable indicating the progress of experiment
	public static StringBuilder data_array;

	// copied
	public List<string[]> data_row = new List<string[]>();

	// Use this for initialization
	void Start () {

		exp_progess = "experiment initiated ";
		trial_number = 1;
		Debug.Log ("current experiment progress: " + exp_progess); // display current experiment progess
		Debug.Log ("current trial number: " + trial_number); // display current trial number

		// name expeirment log after the time the experiment started
		DateTime exp_starting_time = DateTime.Now; 
		name_of_log_file = exp_starting_time.ToString ("MM_dd_HH_mm"); // log file's name is the starting time
		Debug.Log ("experiment started at the following time: " + name_of_log_file);
		Debug.Log ("experiment starting time would be the name of experiment log");

	
		// delcare a one-dimension string object to contain data
		// assign the first row (column title)
		string[] temp_data_row = new string[5]; // a temporary string container of 4 columns
		temp_data_row[0] = "serial_number";
		temp_data_row[1] = "elapsed_time";
		temp_data_row[2] = "trial_number";
		temp_data_row[3] = "responded target";
		temp_data_row[4] = "rt";

		// To write titles in the 1st row
		data_row.Add(temp_data_row);

		Debug.Log ("number of log columns: "+temp_data_row.GetLength(0));
		Debug.Log ("1st column: "+temp_data_row[0]);
		Debug.Log ("2nd column: "+temp_data_row[1]);
		Debug.Log ("3rd column: "+temp_data_row[2]);
		Debug.Log ("4th column: "+temp_data_row[3]);
		Debug.Log ("5th column: "+temp_data_row[4]);

		// You can add up the values in as many cells as you want.
		for(int i = 0; i < 10; i++){
			temp_data_row = new string[3];
			temp_data_row[0] = "Sushanta"+i; // name
			temp_data_row[1] = ""+i; // ID
			temp_data_row[2] = "$"+UnityEngine.Random.Range(5000,10000); // Income
			data_row.Add(temp_data_row);
		}


		string[][] data_row_to_array = new string[data_row.Count][]; // To make a 2-dimensional array fitting data_row
		// Show the number of data row


		// transfer data in data_row to array
		for (int i = 0; i < data_row_to_array.Length; i++) {
			data_row_to_array [i] = data_row [i];
		}

		data_array = new StringBuilder ();

		for (int array_index = 0; array_index < data_row_to_array.Length; array_index++) {
			data_array.AppendLine(string.Join("," , data_row_to_array[array_index]));
		}

		// Debug.Log (data_array); // To show content of data_array in console
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void savelogascsv(){ // save experiment log as a CSV file
		string file_path = @"Assets/"+ name_of_log_file + ".csv"; // where log file will be saved
		File.WriteAllText(file_path , data_array.ToString());

	}
}
