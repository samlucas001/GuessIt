using UnityEngine;
using System.Collections;

public class SettingsInstructionsClick : MonoBehaviour 
{

	void OnClick()
	{
		CameraController.HideCamera("CameraInstructions", "Instructions");
		CameraController.HideCamera("CameraSettings", "Nothing");
		print (MainPageController.originalInstructions);
	}

}
