using UnityEngine;
using System.Collections;

public class SettingsClick : MonoBehaviour 
{

	void OnClick()
	{
		CameraController.HideAllBut("CameraSettings", "Settings");
	}

}
