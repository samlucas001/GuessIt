using UnityEngine;
using System.Collections;

public class MainPageController : MonoBehaviour {

	public static string originalInstructions;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public static void UpdateUserName()
	{
		GameObject go = GameObject.Find("lblUserName");
		UILabel lbl = go.GetComponent<UILabel>();
		lbl.text = PlayerPrefs.GetString("CurrentUserName");

		if(PlayerPrefs.GetString("ShowInstructions") == "true")
		{
			CameraController.HideCamera("CameraInstructions", "Instructions");
			
			go = GameObject.Find("lblInstructions");
			lbl = go.GetComponent<UILabel>();
			
			//make sure we keep a copy of the instructions in case we view the start ones, they change to below
			//we then go and view instructions and OMG they are the cahnged ones we want the original then.
			originalInstructions = lbl.text;
			
			//print (originalInstructions);
			
			string totalText = "Welcome to GuessIt.\nThis looks like it is your first time here.\n";
			totalText = totalText + lbl.text;
			totalText = totalText + "\nSeeing as though this is your first shot, go ahead and either find a friend or start a game with a random person";
			
			lbl.text = totalText;
		}
		
		else
		{
			CameraController.HideCamera("CameraInstructions", "Nothing");
		}


	}
}
