using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{ 

	public void GoToStartGame()
	{
		SceneManager.LoadScene("Chapter 0");
	}

	public void GoToInstructions()
	{
		SceneManager.LoadScene("Instructions");
	}

	public void GoToCredits()
	{
		SceneManager.LoadScene("Credits");
	}

	public void GoToMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
