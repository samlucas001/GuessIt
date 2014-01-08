using UnityEngine;
using System.Collections;

public class MainPageController : MonoBehaviour {

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

	}
}
