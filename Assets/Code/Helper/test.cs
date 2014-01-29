using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class test : MonoBehaviour 
{
	Texture2D tex;
	public GameObject obj;
	string data = string.Empty;
	public static string imageId;
	public static bool haveAnId;

	void Start()
	{
		tex = new Texture2D(300, 200);
		haveAnId = false;
	}

	void Update()
	{
		
		if (haveAnId)
		{
			StartCoroutine(LoadImage());
			haveAnId = false;
		}
	}

	void OnClick()
	{

		StartCoroutine(GetAnImageId());
	}

	private IEnumerator GetAnImageId()
	{
		WWW hs_post = new WWW("http://guessit.azurewebsites.net/GetRandomImage.php");


		yield return hs_post;
		haveAnId = true;
		imageId = hs_post.text;

	}


	private IEnumerator LoadImage()
	{

		WWW hs_post = new WWW("http://guessit.azurewebsites.net/__ImageView.php?imageId=" + imageId);
		yield return hs_post;

		foreach(KeyValuePair<string, string> i in hs_post.responseHeaders)
		{
			data += "Key : " + i.Key + "   Value: " + i.Value + "\n";
		}

		data += "Size : " + hs_post.size.ToString() + "\n";
		data += "Data : " + hs_post.data.ToString() + "\n";

		//print(data);

		tex.LoadImage(hs_post.bytes);

		//var tabs = hs_post.text.Split("\n"[0]);
		//print (data);

		GameObject go1 = GameObject.Find("GameObject");
		go1.renderer.material.mainTexture = tex;


		//GameObject go = GameObject.Find("GameObject1");
		//SpriteRenderer sprite = go.GetComponent<SpriteRenderer>();
		//sprite.renderer.material.mainTexture = tex;

		//GameObject go2 = GameObject.Find("GameObject2");
		//GUITexture gui = go.GetComponent<GUITexture>();
		//gui.renderer.material.mainTexture = tex;
		//obj.renderer.material.mainTexture = tex;

	}


}
