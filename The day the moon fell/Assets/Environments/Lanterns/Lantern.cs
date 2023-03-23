using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lantern : MonoBehaviour
{
	[SerializeField] private Sprite unlit;
	[SerializeField] private Sprite lit;
	private bool LanternIsOn = false;

	public static event System.Action LanternLit;

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
		LanternLit?.Invoke();
		
	}
}
