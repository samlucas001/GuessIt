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

}
