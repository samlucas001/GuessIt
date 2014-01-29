using UnityEngine;
using System.Collections;

public class MainPageController : MonoBehaviour {

	public static string originalInstructions;
	public Rect windowRect = new Rect(20, 50, 50, 20);
	public GUISkin guiSkin;
	public static string userGUID;

	void Start()
	{
		Helper.CurrentMenuLocation = (int)Helper.eCurrentMenuLocation.Home;
		Helper.MoveSomething("lstFindList", -5000);
		userGUID = PlayerPrefs.GetString("PlayerGUID");
	}

	void OnGUI()
	{
		//GUI.skin = guiSkin;
		//windowRect = GUI.ModalWindow(0, new Rect(15, 200, 300, 120), DoMyWindow, "");
	
	}
	
	void DoMyWindow(int WindowsId)
	{
		//string userName = "bnalala";

		//GUI.Label(new Rect(6, 25, 285, 100), "Are you sure you want to add\n" + userName);

		//if(GUI.Button(new Rect(45, 83, 85, 20), "OK"))
		//{
		//	print("pressed OK");
		//}
		//if(GUI.Button(new Rect(172, 83, 85, 20), "Cancel"))
		//{
		//	print("pressed Cancel");
		//}
		
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
