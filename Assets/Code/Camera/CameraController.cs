using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	static public void HideCamera(string camera, string layer)
	{
		GameObject cam = GameObject.Find(camera);
		Camera c = cam.GetComponent<Camera>();
		int i = LayerMask.NameToLayer(layer);
		c.cullingMask = 1 << i;
	}

	static public void HideAllBut(string camera, string layer)
	{
		
		CameraController.HideCamera("CameraSettings", "Nothing");
		CameraController.HideCamera("CameraLeaderboard", "Nothing");
		CameraController.HideCamera("CameraFriendsRequests", "Nothing");
		CameraController.HideCamera("CameraNewGame", "Nothing");
		CameraController.HideCamera("CameraFriendList", "Nothing");
		CameraController.HideCamera(camera, layer);
		Helper.HideStartInstructions();
		Helper.MoveSomething("lstFindList", -5000);

	}

}
