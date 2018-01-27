using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasManagingScript : MonoBehaviour 
{
	public GameObject startCanvas;

	public void OnPress() 
	{
		startCanvas.SetActive(false);
	}
}
