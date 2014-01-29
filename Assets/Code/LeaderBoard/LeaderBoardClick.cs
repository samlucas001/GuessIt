using UnityEngine;
using System.Collections;

public class LeaderBoardClick : MonoBehaviour 
{

	void OnClick()
	{
		Helper.CurrentMenuLocation = (int)Helper.eCurrentMenuLocation.Leaderboard;
		CameraController.HideAllBut("CameraLeaderboard", "Leaderboard");
	}

}
