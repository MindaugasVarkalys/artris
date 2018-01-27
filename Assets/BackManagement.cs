using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackManagement : MonoBehaviour 
{
	public string menu;
	
	public void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			GoToMenu();
		}
	}
	
	public void GoToMenu () 
	{
		SceneManager.LoadScene(menu);
	}
}
