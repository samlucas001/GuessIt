using UnityEngine;
using System.Collections;

public class FindFriendClick : MonoBehaviour 
{
	public bool hasBeenClicked;
	public static int dots;
	public static float time;
	public bool searching;
	public bool doneSearching;
	public bool hasBeenUpdated;

	void Start()
	{
		hasBeenClicked = false;
		searching = false;
		doneSearching = false;

	}

	void Update()
	{
		if(hasBeenClicked)
		{
			if (searching)
			{
				if (Time.time > time)
				{
					GameObject go = GameObject.Find("lblSearchingFriend");
					UILabel lbl = go.GetComponent<UILabel>();

					string dotTotal = "Searching";
					for (int i = 0; i < dots; i++)
					{
						dotTotal += ".";
					}
					
					dots++;
					dots = dots > 5 ? 0 : dots;
					lbl.text = dotTotal;
					
					time = Time.time + 1;
				}
			}

		}

	}

	void OnClick()
	{
		string searchTest = Helper.GetLabelText("lblFriendSearch");
		searchTest.Replace("----", "");
		searchTest.Trim();

		if (searchTest != "")
		{
			hasBeenClicked = true;
			time = Time.time + 0.001f;
			StartCoroutine(GetFreind());
		}
	}

	IEnumerator GetFreind()
	{
		string searchType = Helper.GetLabelText("lblSearchForWho");
		searchType = searchType == "USERNAME" ? "AccountUserName" : "AccountEmail";
		string searchFor = Helper.GetLabelText("lblFriendSearch");
		searching = true;

		WWW hs_post = new WWW("http://guessit.azurewebsites.net/FindFriend.php?searchString=" + searchFor + "&searchType=" + searchType);

		yield return hs_post;
		searching = false;
		UpdateSearchResults(hs_post.text);

		//print(hs_post.text);

	}

	void UpdateSearchResults(string results)
	{
		Helper.UpdateLabelText("lblSearchingFriend", results);

	}


}
