using UnityEngine;
using System.Collections;

public class NewGameClick : MonoBehaviour 
{
	
	void OnClick()
	{
		CameraController.HideAllBut("CameraNewGame", "NewGame");
	}

}
