using UnityEngine;
using System.Collections;
using System;

public class CreateNewPlayerOKClick : MonoBehaviour 
{
	public static bool hasLoaded = false;
	public static bool needToCheckUser = false;
	public static WWW getName;
	public static bool isChecking;
	public static int dots;
	public static float time;
	public static string webAnswer;
	public static bool allDone;

	// Update is called once per frame
	void Update () 
	{
		if (isChecking)
		{
			if (Time.time > time)
			{
				GameObject go = GameObject.Find("lbl07Checking");
				UILabel lbl = go.GetComponent<UILabel>();

				string dotTotal = "Checking user name";
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

		if (hasLoaded)
		{
			if (webAnswer == "safe")
			{
				GameObject go = GameObject.Find("lbl01UserName");
				UILabel lbl = go.GetComponent<UILabel>();

				PlayerPrefs.SetString("CurrentUserName", lbl.text);
				PlayerPrefs.Save();

				if (!allDone)
				{
					StartCoroutine(InsertDetails());
				}

			}
			else
			{
				Vector3 sadTrans = GameObject.Find("img01SadFace").transform.localPosition;
				sadTrans.x = 256;
				GameObject.Find("img01SadFace").transform.localPosition = sadTrans;

				GameObject go = GameObject.Find("lbl07Checking");
				UILabel lbl = go.GetComponent<UILabel>();
				lbl.text = "User name exists";
				//MoveFaces("lbl01UserName", "img01SadFace");
			}
		}
	}



	private IEnumerator InsertDetails()
	{
		string userName = Helper.GetLabelText("lbl01UserName");
		string name = Helper.GetLabelText("lbl02Name");
		string email = Helper.GetLabelText("lbl03Email");
		string password = Helper.GetPasswordText("txt04Password");
		string guid = Guid.NewGuid().ToString();
		string playWith = Helper.GetLabelText("lblPlayWith");
		allDone = true;

		WWW hs_post = new WWW("http://guessit.azurewebsites.net/AddUser.php?username=" + userName + "&name=" + name + "&email=" + email + "&password=" + password + "&guid=" + guid + "" + "&playWith=" + playWith + "");

		yield return hs_post;
		

		PlayerPrefs.SetString("PlayerGUID", guid);
		PlayerPrefs.Save();

		PlayerPrefs.SetString("ShowInstructions", "true");
		PlayerPrefs.Save();

		CameraController.HideCamera("CreateNewPlayerCamera", "Nothing");
		CameraController.HideCamera("CameraHome", "Home");			
		MainPageController.UpdateUserName();
	}

	void Start()
	{
		hasLoaded = false;
		isChecking = false;
		dots = 0;
		webAnswer = "";
		allDone = false;

		if (PlayerPrefs.HasKey("CurrentUserName"))
		{
			CameraController.HideCamera("CreateNewPlayerCamera", "Nothing");
			CameraController.HideCamera("CameraHome", "Home");			
			MainPageController.UpdateUserName();
		}
		else
		{
			CameraController.HideCamera("CreateNewPlayerCamera", "CreateNewPlayer");
			CameraController.HideCamera("CameraHome", "Nothing");
			//CameraController.HideCamera("CreateNewPlayerCamera", "Nothing");
			//CameraController.HideCamera("CameraNewResumeGame", "NewResumeGame");	
		}


	}

	void OnClick()
	{
		//GameObject go = GameObject.Find("btnOK");
		//UIButton btn = go.GetComponent<UIButton>();
		//btn.isEnabled = false;

		bool hasPassed = false;
		//CheckUserName();
		//check that nothing is blank
		hasPassed = MoveFaces("lbl01UserName", "img01SadFace");
		needToCheckUser = true;
		hasPassed = MoveFaces("lbl02Name", "img02SadFace");
		hasPassed = MoveFaces("lbl04Password", "img04SadFace");
		hasPassed = MoveFaces("lbl05ReEnter", "img04SadFace");

		if (CheckPassword())
		{
			//MoveFaces("lbl04Password", "img04SadFace");
			hasPassed = true;
		}
		else
		{
			hasPassed = false;
		}

		if(hasPassed)
		{
			StartCoroutine(CheckUserName());
		}

		if (hasPassed && hasLoaded)
		{
			//if (PlayerPrefs.HasKey("showCountDownTimer"))
			//{
			//	PlayerPrefs.SetString("CurrentUserName", UserName.CurrentUserName);
			//	PlayerPrefs.Save();
			//}

			CameraController.HideCamera("CreateNewPlayerCamera", "Nothing");
			CameraController.HideCamera("CameraNewResumeGame", "Home");

			PlayerPrefs.SetString("CurrentUserName", GetLabelValue("lbl01UserName"));
			PlayerPrefs.Save();

			PlayerPrefs.SetString("ShowInstructions", "true");
			PlayerPrefs.Save();


			MainPageController.UpdateUserName();
		}
	}

	private IEnumerator CheckUserName()
	{
		GameObject go = GameObject.Find("lbl01UserName");
		UILabel lbl = go.GetComponent<UILabel>();

		WWW hs_post = new WWW("http://guessit.azurewebsites.net/CheckUser.php?userName=" + lbl.text);
		
		
		go = GameObject.Find("lbl07Checking");
		lbl = go.GetComponent<UILabel>();
		lbl.text = "Checking user name";
		isChecking = true;
		time = Time.time + 1;
		//var lines = getName.text;

		yield return hs_post;
		webAnswer = hs_post.text;
		//print (hs_post.text);
		isChecking = false;
		hasLoaded = true;

	}

	public static string GetLabelValue(string ObjectName)
	{
		GameObject go = GameObject.Find(ObjectName);
		UILabel lbl = go.GetComponent<UILabel>();

		return lbl.text;

	}

	static bool CheckPassword()
	{
		string password1;
		string password2;
		bool tempCheck = false;

		password1 = Helper.GetPasswordText("txt04Password"); 
		password2 = Helper.GetPasswordText("txt05ReEnter"); 

		if(password1 != password2 || password1 == "----")
		{
			Vector3 sadTrans = GameObject.Find("img04SadFace").transform.localPosition;
			sadTrans.x = 258;
			GameObject.Find("img04SadFace").transform.localPosition = sadTrans;

			sadTrans = GameObject.Find("img05SadFace").transform.localPosition;
			sadTrans.x = 258;
			GameObject.Find("img05SadFace").transform.localPosition = sadTrans;

			tempCheck = false;
		}
		else 
		{
			Vector3 sadTrans = GameObject.Find("img04SadFace").transform.localPosition;
			sadTrans.x = 500;
			GameObject.Find("img04SadFace").transform.localPosition = sadTrans;
			
			sadTrans = GameObject.Find("img05SadFace").transform.localPosition;
			sadTrans.x = 500;
			GameObject.Find("img05SadFace").transform.localPosition = sadTrans;

			tempCheck = true;
		}

		return tempCheck;

	}

	static bool MoveFaces(string labelName, string imageName)
	{
		bool tempCheck = false;
		GameObject go = GameObject.Find(labelName);
		UILabel lbl = go.GetComponent<UILabel>();
		string checkValue = lbl.text.Replace("----", "");
		checkValue = checkValue.Replace(" ", "");
		
		if (checkValue == "")
		{
			Vector3 sadTrans = GameObject.Find(imageName).transform.localPosition;
			sadTrans.x = 256;
			GameObject.Find(imageName).transform.localPosition = sadTrans;
			tempCheck = false;
		}
		else
		{
			Vector3 sadTrans = GameObject.Find(imageName).transform.localPosition;
			sadTrans.x = 500;
			GameObject.Find(imageName).transform.localPosition = sadTrans;
			tempCheck = true;
		}

		return tempCheck;
	}
}
