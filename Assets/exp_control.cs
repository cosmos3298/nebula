using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class exp_control : MonoBehaviour {

	public	static	int illustration_progress = 0;
	public	static	int number_illustration;

	// To assign the number of total trial number and the starting trial number
	public static int total_trial_number = 5; 
	public static int starting_trial_number = 1;

	public	static	GameObject[] exp_illustration;

	public GameObject button_for_back;
	public Image image_back_button;
	public Button button_back_button;
	public Text text_back_button;

	// The following GameObjects need to be assigned in Unity Inspector,
	// simply by using your mouse cursor to drag-and-drop 
	public GameObject text0;
	public GameObject text1;
	public GameObject text2;
	public GameObject text3;



	public Text text_on_screen; // 

	// Use this for initialization
	public void Start () {
		// To define pages of experiment illustration as individual GameObjects
		//GameObject text0 = GameObject.Find ("Text0");
		//GameObject text1 = GameObject.Find ("Text1");	
		//GameObject text2 = GameObject.Find ("Text2");
		//GameObject text3 = GameObject.Find ("Text3");


		GameObject[] exp_illustration = { text0, text1, text2, text3};

		number_illustration = exp_illustration.Length;
	
//		Debug.Log ("number of pages of illustration: " + exp_illustration.Length);
//		Debug.Log (exp_illustration [0].name);


		 //To Turn on the first page of illustration and turn off all the others
		for (int illustration_index = 0; illustration_index < exp_illustration.Length; illustration_index++) {
			
			GameObject text_obj = exp_illustration [illustration_index];
			text_on_screen= text_obj.GetComponentsInChildren<Text>()[0];

				if (illustration_index == 0) {
				//exp_illustration [illustration_index].SetActive (true); // To turn on the first page
					text_on_screen.enabled = true;
				} 
				else {
					//exp_illustration [illustration_index].SetActive (false); // To turn off all the others
					text_on_screen.enabled = false;

				}
		}

		// To turn off back button at first
		button_for_back = GameObject.Find("back_button");
		image_back_button = button_for_back.GetComponentsInChildren<Image> ()[0];
		button_back_button = button_for_back.GetComponentsInChildren<Button> ()[0];
		text_back_button = button_for_back.GetComponentsInChildren<Text> ()[0];

		// The following 3 objects controlled the appearance of back button
		image_back_button.enabled = false;
		button_back_button.enabled =false;
		text_back_button.enabled =false;

	}

	/* The proceed_button and back_button described how to move illustration forwards and backwars.
	 * The GameObject: "illustrattion to be closed" & "illustraion to be opened" are the critical lines describing
	 * what GameObject to be opened & closed.
	 * All the pages of illustration are defined by the array of GameObjects: "exp_illustration." 
	 * The progress of illustration is controlled by the index: "illustration_progress."
	 */
	 public void proceed_button(){
		
			if (illustration_progress  < number_illustration-1) { 
	//		exp_illustration [illustration_progress].SetActive (false); Reading index of array seemed unsupported

			GameObject illustration_to_be_closed = GameObject.Find ("Text"+illustration_progress);
				//		illustration_to_be_closed.SetActive (false);
				text_on_screen = illustration_to_be_closed.GetComponentInChildren <Text> ();
				text_on_screen.enabled = false;

			illustration_progress++; //  illustration progress index + 1

			GameObject illustration_to_be_opened = GameObject.Find ("Text"+illustration_progress);
				//illustration_to_be_opened.SetActive (false);
				text_on_screen = illustration_to_be_opened.GetComponentInChildren <Text> ();
				text_on_screen.enabled = true;
						
			}

			// To turn off UI canvas when a user finished illustration
			else if (illustration_progress == number_illustration-1){
				GameObject ui_canvas = GameObject.Find ("Canvas");
				ui_canvas.SetActive (false);

				// To move on to experiment with 5 trials and the starting trial number being 1
				exp_starter.exp_start(5,1);
			}

		// To turn on & off the back button 
		if (illustration_progress > 0) {
			image_back_button.enabled = true;
			button_back_button.enabled = true;
			text_back_button.enabled = true;
		} 
		else if (illustration_progress == 0) {
			image_back_button.enabled = false;
			button_back_button.enabled = false;
			text_back_button.enabled = false;
		}

		Debug.Log(illustration_progress+" / "+ number_illustration);

		Debug.Log ("proceed button was clicked");

	}

	public void back_button(){
		
		if (illustration_progress  > 0) { 
			//		exp_illustration [illustration_progress].SetActive (false); Reading index of array seemed unsupported

			GameObject illustration_to_be_closed = GameObject.Find ("Text"+illustration_progress);
			//		illustration_to_be_closed.SetActive (false);
			text_on_screen = illustration_to_be_closed.GetComponentInChildren <Text> ();
			text_on_screen.enabled = false;

			illustration_progress--; //  illustration progress index - 1

			GameObject illustration_to_be_opened = GameObject.Find ("Text"+illustration_progress);
			//illustration_to_be_opened.SetActive (false);
			text_on_screen = illustration_to_be_opened.GetComponentInChildren <Text> ();
			text_on_screen.enabled = true;

		}

		// To turn off the back button on the first page
		if (illustration_progress == 0) {
			image_back_button.enabled = false;
			button_back_button.enabled = false;
			text_back_button.enabled = false;
		}

		Debug.Log(illustration_progress+" / "+ number_illustration);

		Debug.Log ("back button was clicked");

	}


}