using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class LargeTextHandling : MonoBehaviour
{
	[SerializeField] Image Background;
	PlayerInput m_Input;
	int lineNo = 1;
	[SerializeField] TextScriptable dialogue;
	private TextMeshProUGUI text;
	[SerializeField] GameObject player;
	static bool FirstCalled = false;


	// Start is called before the first frame update
	void Start()
    {
		m_Input = GetComponent<PlayerInput>();
		m_Input.currentActionMap.FindAction("Next").performed += nextText;
		text = GetComponent<TextMeshProUGUI>();
		text.text = dialogue.speech[0];
		player.GetComponent<PlayerMovement>().enabled= false;
	}

    void nextText(InputAction.CallbackContext context)
	{
		if (lineNo < dialogue.speech.Length)
		{
			text.text = dialogue.speech[lineNo];
			lineNo++;
		}
		else
		{
			if (SceneManager.GetActiveScene().name == "Chapter 2" && FirstCalled == true)
			{
				SceneManager.LoadScene("Menu");
			}
			FirstCalled = true;
			StartCoroutine(fade());
			player.GetComponent<PlayerMovement>().enabled = true;
			text.enabled = false;
			
		}
		
	}

	IEnumerator fade()
	{
		while (Background.color.a > 0)
		{
			Background.color = new Color(1f, 1f, 1f, Background.color.a - 0.01f);
			yield return new WaitForFixedUpdate();
		}
		
		gameObject.transform.parent.gameObject.SetActive(false);
	}
}
