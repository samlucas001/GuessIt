using UnityEngine;
using System.Collections;

public class ButtonPrefabClick : MonoBehaviour {

	bool hasBeenClicked;
	public Rect windowRect = new Rect(20, 50, 50, 20);
	public Rect windowRect1 = new Rect(20, 50, 50, 20);
	public GUISkin guiSkin;
	public static string userNameToAdd;
	public static bool shouldWeBeShowing;
	public bool waitingToAddFriend;
	public string modalHeader;
	public string cancelButton;

	ModalDialog.ModalBool showTwoButtonDialog;

	void Awake()
	{
		showTwoButtonDialog = new ModalDialog.ModalBool(true);
	}

	// Use this for initialization
	void Start () 
	{
		hasBeenClicked = false;
		userNameToAdd = string.Empty;
		shouldWeBeShowing = true;
		waitingToAddFriend = false;
		modalHeader = "";
		cancelButton = "Cancel";
	}

	void OnGUI()
	{
		if(hasBeenClicked && shouldWeBeShowing)
		{
			GameObject go = GameObject.Find("btnModalClick");

			Helper.SetLayerRecursively(go, 13);

			GUI.skin = guiSkin;
			//windowRect1 = GUI.Window(1, new Rect(0, 0, 3000, 3000), null, "");
			windowRect = GUI.ModalWindow(0, new Rect(15, 200, 300, 120), DoMyWindow, modalHeader);
		}
	}

	void DoMyWindow(int WindowsId)
	{
		if (cancelButton == "Cancel")
		{
			GUI.Label(new Rect(6, 25, 285, 100), "Are you sure you want to add\n" + userNameToAdd);
		}
		else
		{
			GUI.Label(new Rect(6, 25, 285, 100), "You are already friends with\n" + userNameToAdd);
		}

		if(GUI.Button(new Rect(45, 83, 85, 20), "OK"))
		{
			//wow they want to add someone..... where to now
			//firstly add this friend as someone in the database that this faggot wants to be friend with
			if (cancelButton == "Cancel")
			{
				StartCoroutine(AddFriend());

				if (!waitingToAddFriend)
				{
					Helper.MoveSomething("btnModalClick", 5000);
					shouldWeBeShowing = false;
					cancelButton = "Cancel";
				}
			}
			else
			{
				Helper.MoveSomething("btnModalClick", 5000);
				shouldWeBeShowing = false;
				cancelButton = "Cancel";
			}
		}

		if(GUI.Button(new Rect(172, 83, 85, 20), cancelButton))
		{
			//just close the window they dcnt give a shit
			Helper.MoveSomething("btnModalClick", 5000);
			shouldWeBeShowing = false;
			cancelButton = "Cancel";
		}

	}

	IEnumerator AddFriend()
	{
		waitingToAddFriend = true;

		string guid = PlayerPrefs.GetString("PlayerGUID");
		WWW hs_post = new WWW("http://guessit.azurewebsites.net/AddFriend.php?UserGUID=" + guid + "&FriendId=" + Helper.FriendClickedId);
		modalHeader = "Sending request";

		yield return hs_post;
		waitingToAddFriend = false;

		if(hs_post.text == "Friend")
		{
			cancelButton = "Close";
			modalHeader = "";
		}
		else
		{
			cancelButton = "Cancel";
			shouldWeBeShowing = false;
			modalHeader = "";

			ListFindChange.WhatToShowInFriends = "LIST";
			FriendsClick fc = new FriendsClick();
			fc.UpdateFriendsPage();
			Helper.UpdateLabelText("lblFindOrListResults", "LIST");
		}

	}

	void OnClick()
	{
		//UIButton btn = this.transform.FindChild("btnFindAFriend").GetComponent<UIButton>();
		UILabel lbl =  this.transform.FindChild("lblATitle").GetComponent<UILabel>();
		int bracketLocation = lbl.text.IndexOf("(");
		string returnName = lbl.text.Substring(0, bracketLocation);
		userNameToAdd = returnName;

		Helper.MoveSomething("btnModalClick", 0);

		lbl = this.transform.FindChild("lblFriendId").GetComponent<UILabel>();
		Helper.FriendClickedId = int.Parse(lbl.text);

		hasBeenClicked = true;
		shouldWeBeShowing = true;
		Time.timeScale = 0;
	}

}
