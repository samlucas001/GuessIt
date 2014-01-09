using UnityEngine;
using System.Collections;

public class LeaderBoardClick : MonoBehaviour 
{

	void OnClick()
	{
		CameraController.HideAllBut("CameraLeaderboard", "Leaderboard");
	}

}
