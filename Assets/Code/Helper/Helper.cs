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

	static public void UpdateLabelText(string labelName, string textToAdd)
	{
		GameObject go = GameObject.Find(labelName);
		UILabel lbl = go.GetComponent<UILabel>();
		lbl.text = textToAdd;

	}

	static public void CloneResource(string panel, string resource, float yLoc, string labelText)
	{
		GameObject pnl = GameObject.Find(panel);
		GameObject instance = Resources.Load(resource) as GameObject;
		GameObject item = NGUITools.AddChild(pnl, instance);
		
		//item.name = "FriendDelete";
		item.tag = resource;
		item.transform.localPosition = new Vector3(-60.0f, yLoc, 0.0f);
		item.transform.localScale = new Vector3(1.0f, 0.75f, 1.0f);

		if (labelText != "")
		{
			UIButton btn = item.transform.FindChild("btnFindAFriend").GetComponent<UIButton>();
			UILabel lbl =  btn.transform.FindChild("lblATitle").GetComponent<UILabel>();
			lbl.text = labelText;
		}
	}
	
	static public void ChangeButtonState(string buttonName, bool enabled)
	{
		GameObject go = GameObject.Find(buttonName);
		UIButton btn = go.GetComponent<UIButton>();
		btn.enabled = enabled;

	}

}
