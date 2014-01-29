using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendsClick : MonoBehaviour 
{
	public class friendList
	{
		public int userId;
		public string userName;
		public string userEmail;

		public friendList(int userId, string userName, string userEmail)
		{
			this.userId = userId;
			this.userName = userName;
			this.userEmail = userEmail;
		}

	}

	static public List<friendList> FriendList = new List<friendList>();
	public static bool requestedList;
	
	void OnClick()
	{
		Helper.CurrentMenuLocation = (int)Helper.eCurrentMenuLocation.Friends;
		UpdateFriendsPage();
	}

	void Update()
	{


	}

	void Start()
	{
		requestedList = false;
	}

	public void UpdateFriendsPage()
	{
		if (Helper.CurrentMenuLocation == (int)Helper.eCurrentMenuLocation.Friends)
		{
			if (ListFindChange.WhatToShowInFriends == "FIND")
			{
				CameraController.HideAllBut("CameraFriendsRequests", "FriendsRequests");
				Helper.MoveSomething("lstFindList", 479);
				//GameObject cam = GameObject.Find("CameraFriendsRequests");
				//Camera c = cam.GetComponent<Camera>();
				//int i = LayerMask.NameToLayer("FriendsRequests");
				//int ii = LayerMask.NameToLayer("FriendHeader");
				//c.cullingMask = 1 << i | 1 << ii;
				//int i = LayerMask.NameToLayer("FriendsRequests");
				//c.cullingMask = 1 << i;
			}
			else
			{
				CameraController.HideAllBut("CameraFriendList", "FriendsList");
				Helper.MoveSomething("lstFindList", 479);
				//GameObject cam = GameObject.Find("CameraFriendsRequests");
				//Camera c = cam.GetComponent<Camera>();
				//int i = LayerMask.NameToLayer("FriendsList");
				//c.cullingMask = 1 << i;
				ListFriends();
			}
		}
	}

	public void ListFriends()
	{
		if(!requestedList)
		{
			requestedList = true;
			StartCoroutine(GetFriendList());
		}

	}


	IEnumerator GetFriendList()
	{
		string userGUID = MainPageController.userGUID;
		WWW hs_post = new WWW("http://guessit.azurewebsites.net/GetFriends.php?userGUID=" + userGUID);



		yield return hs_post;
		UpdateFriendsPage();

		FriendList.Clear();

		var lines = hs_post.text.Split("\n"[0]);

		for (int i = 0; i <= lines.Length - 1; i++)
		{
			if(lines[i] != "")
			{
				var tabs = lines[i].Split("\t"[0]);
				FriendList.Add(new friendList(int.Parse(tabs[0].ToString()), tabs[1].ToString(), tabs[2].ToString()));
			}
		}

		print (FriendList.Count);

		//print(hs_post.text);

	}


}
