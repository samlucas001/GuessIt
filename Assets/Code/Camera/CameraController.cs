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

}
