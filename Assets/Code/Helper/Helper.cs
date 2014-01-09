using UnityEngine;
using System.Collections;

public class Helper : MonoBehaviour 
{
	static public string GetLabelText(string labelName)
	{
		GameObject go = GameObject.Find(labelName);
		UILabel lbl = go.GetComponent<UILabel>();

		return lbl.text;

	}

	static public string GetPasswordText(string labelName)
	{
		GameObject go = GameObject.Find(labelName);
		UIInput inp = go.GetComponent<UIInput>();
		return inp.value;
		
	}

	static public void HideStartInstructions()
	{
		CameraController.HideCamera("CameraInstructions", "Nothing");

		PlayerPrefs.SetString("ShowInstructions", "false");
		PlayerPrefs.Save();

		if(!string.IsNullOrEmpty(MainPageController.originalInstructions))
		{
			
			
			GameObject go = GameObject.Find("lblInstructions");
			UILabel lbl = go.GetComponent<UILabel>();

			lbl.text = "";
			lbl.text = MainPageController.originalInstructions;
		}


	}

}
