using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSinglePlayer : MonoBehaviour {

	public void LoadScene1()
	{
		SceneManager.LoadScene ("level1");
	}
	public void LoadScene2()
	{
		SceneManager.LoadScene ("level2");
	}
}

