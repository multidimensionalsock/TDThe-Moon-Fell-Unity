using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
	public static DontDestroy Instance = null;
    void Awake()
    {
		if (Instance == null)
		{
			Instance = this;
			Debug.Log("made instance");
		}
		else
		{
			Debug.Log("destoryed");
			Destroy(gameObject);
		}

		
        DontDestroyOnLoad(this);
		SceneManager.sceneLoaded += CheckLevel;


	}

	private void CheckLevel(Scene scene, LoadSceneMode mode)
	{
		if (SceneManager.GetActiveScene().name == "Chapter 0" ||
			SceneManager.GetActiveScene().name == "Chapter 1" ||
			SceneManager.GetActiveScene().name == "Chapter 2")
		{
			Debug.Log("one of them");
			this.GetComponent<AudioSource>().Pause();
		}
		else
		{
			Debug.Log("not one of them");
			if (gameObject.GetComponent<AudioSource>().isPlaying == false)
			{
				this.GetComponent<AudioSource>().Play();
			}
		}
	}


}
