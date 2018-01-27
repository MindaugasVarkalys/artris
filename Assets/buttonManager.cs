using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class buttonManager : MonoBehaviour 
{
	public string scene1;
	public string scene2;

	public void LoadSceneTutorial () 
	{
		 SceneManager.LoadScene(scene1);
	}
	
	public void LoadSceneMain () 
	{
		 SceneManager.LoadScene(scene2);
	}
}
