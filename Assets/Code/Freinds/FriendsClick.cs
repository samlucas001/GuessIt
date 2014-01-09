using UnityEngine;
using System.Collections;

public class FriendsClick : MonoBehaviour 
{
	
	void OnClick()
	{
		CameraController.HideAllBut("CameraFriends", "Friends");
	}

}
