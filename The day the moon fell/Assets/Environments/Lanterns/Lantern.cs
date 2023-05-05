using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lantern : MonoBehaviour
{
	[SerializeField] private Sprite unlit;
	[SerializeField] private Sprite lit;
	public bool LanternIsOn = false;
	[SerializeField] GameObject LanternUI;
	PlayerInput m_input;

	public static event System.Action LanternLit;

    private void Start()
    {
		LanternUI = transform.GetChild(0).gameObject;
		LanternUI.active = false;
		m_input = GetComponent<PlayerInput>();
		m_input.currentActionMap.FindAction("Next").performed += End;
	}

    public void LanternOn()
	{
		if (LanternIsOn != true)
		{
			StartCoroutine(on());
		}
		if (gameObject.GetComponent<GoToScene>() != null)
		{
			GetComponent<GoToScene>().ChangeScene();
		}
		
	}

	IEnumerator on()
	{
		yield return new WaitForSeconds(0.2f);
		gameObject.GetComponent<SpriteRenderer>().sprite = lit;
		LanternIsOn = true;
		LanternUI.active = true;
		if (gameObject.GetComponent<EndGameScript>() != null)
		{
			GetComponent<EndGameScript>().StartEndLevel();
		}
        else
        {
			GetComponent<CapsuleCollider2D>().enabled = false;
			LanternLit?.Invoke();
		}

	}
	void End(InputAction.CallbackContext context)
	{
		LanternUI?.SetActive(false);
    }
}
