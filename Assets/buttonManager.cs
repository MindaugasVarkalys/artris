using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class buttonManager : MonoBehaviour 
{
	public string scene;

	public void LoadScene () 
	{
		 SceneManager.LoadScene(scene);
	}
}
