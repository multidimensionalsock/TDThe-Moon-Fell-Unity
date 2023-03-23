using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
	[SerializeField] int sceneNo;
	[SerializeField] GameObject LanternEvents;
    // Start is called before the first frame update
    
	public void ChangeScene()
	{
		if (LanternEvents.GetComponent<LanternEvents>().ProceedToNextLevel() == true)
		{
			SceneManager.LoadScene(sceneNo);
		}
		//else
		//{
		//	//display message saying not all lantners have been lit
		//}
	}
}
