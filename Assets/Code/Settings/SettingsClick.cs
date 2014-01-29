using UnityEngine;
using System.Collections;

public class SettingsClick : MonoBehaviour 
{

	void OnClick()
	{
		Helper.CurrentMenuLocation = (int)Helper.eCurrentMenuLocation.Settings;
		CameraController.HideAllBut("CameraSettings", "Settings");
	}

}
