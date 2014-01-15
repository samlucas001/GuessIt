using UnityEngine;
using System.Collections;

public class ButtonPrefabClick : MonoBehaviour {

	bool hasBeenClicked;
	public Rect windowRect = new Rect(20, 50, 50, 20);
	public GUISkin guiSkin;

	// Use this for initialization
	void Start () 
	{
		hasBeenClicked = false;
	}

	void OnGUI()
	{
		if(hasBeenClicked)
		{
			GUI.skin = guiSkin;
			windowRect = GUI.Window(0, new Rect(20, 200, 290, 100), DoMyWindow, "Are you sure?");
		}
	}

	void DoMyWindow(int WindowsId)
	{
		if(GUI.Button(new Rect(50, 180, 100, 20), "OK"))
		{
			print("pressed OK");
		}
		if(GUI.Button(new Rect(200, 180, 100, 20), "Cancel"))
		{
			print("pressed Cancel");
		}

	}

	void OnClick()
	{

		print ("test1");
		hasBeenClicked = true;

	}

}
