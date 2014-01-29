using UnityEngine;
using System.Collections;

public class ListFindChange : MonoBehaviour
{
	static public string WhatToShowInFriends;

	void Start()
	{

	}

	public void DropDownListChange()
	{
		UILabel lbl = GameObject.Find("lblFindOrListResults").GetComponent<UILabel>();
		WhatToShowInFriends = lbl.text;

		FriendsClick fc = new FriendsClick();
		fc.UpdateFriendsPage();


	}

}
