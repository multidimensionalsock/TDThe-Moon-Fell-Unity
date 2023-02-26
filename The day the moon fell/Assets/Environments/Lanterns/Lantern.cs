using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lantern : MonoBehaviour
{
	[SerializeField] private Sprite unlit;
	[SerializeField] private Sprite lit;

	public void LanternOn()
	{
		Debug.Log("lit");
		gameObject.GetComponent<SpriteRenderer>().sprite = lit;
	}
}
