using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
	static bool exists = false;

	private void Start()
	{
		if (exists == false)
		{
			DontDestroyOnLoad(this);
			exists = true;
		}
	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();

	}
}
