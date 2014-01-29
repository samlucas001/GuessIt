using UnityEngine;
using System.Collections;

public class NewGameClick : MonoBehaviour 
{
	
	void OnClick()
	{
		Helper.CurrentMenuLocation = (int)Helper.eCurrentMenuLocation.New;
		CameraController.HideAllBut("CameraNewGame", "NewGame");
	}

}
