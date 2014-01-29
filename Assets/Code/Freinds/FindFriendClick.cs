using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		//if(hasBeenClicked)
		//{
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

		//}

	}

	void OnClick()
	{
		string searchTest = Helper.GetLabelText("lblFriendSearch");
		searchTest.Replace("----", "");
		searchTest.Trim();

		if (searchTest != "")
		{
			//Helper.ChangeButtonState("btnSearchFriends", false);

			hasBeenClicked = true;
			time = Time.time + 0.001f;
			GameObject[] go1;

			go1 = GameObject.FindGameObjectsWithTag("FindAFriendPrefab");
			
			for(int i = 0; i < go1.Length; i++)
			{
				Destroy(go1[i]);
			}
			dots = 0;
			StartCoroutine(GetFriend());


		}
	}

	IEnumerator GetFriend()
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

		//print(results);
		if(results != "NONE")
		{
			var lines = results.Split("\n"[0]);
			//Helper.UpdateLabelText("lblSearchingFriend", "");

			for (int i = 0; i < lines.Length-1; i++)
			{
				if(i == 0)
				{
					Helper.CloneResource("pnlFriendRequests", "FindAFriendPrefab", 25.0f, "", 0);

					var tabs = lines[0].Split("\t"[0]);
					Helper.UpdateLabelText("lblATitle", tabs[1].ToString() + "(" + tabs[2].ToString() + ")");
					Helper.UpdateLabelText("lblFriendId", tabs[0].ToString());
				}
				else
				{
					float yLoc = 25.0f - (i * 43);
					var tabs = lines[i].Split("\t"[0]);
					string labelText = tabs[1].ToString() + "(" + tabs[2].ToString() + ")";

					Helper.CloneResource("pnlFriendRequests", "FindAFriendPrefab", yLoc, labelText, int.Parse(tabs[0]));
				}

			}



			


			//go = GameObject.Find("FindAFriendPrefab");
			
			//GameObject item = NGUITools.AddChild(go, go);
			//item.name = "BLAH";
			//item.transform.localPosition = new Vector3(0.0f, 150.0f, 0.0f);
			//UIButton btn = item.transform.FindChild("btnFindAFriend").GetComponent<UIButton>();
			
			//UILabel lbl =  btn.transform.FindChild("lblATitle").GetComponent<UILabel>();
			//lbl.text = "dsgffdsgsfdg";
			//////.GetComponent<UILabel>().text = "JASKDJSK";
		}
		else
		{

			Helper.UpdateLabelText("lblSearchingFriend", "No results - try again");

		}




		//

	}


}
