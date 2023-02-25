using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lantern : MonoBehaviour
{
	[SerializeField] private Sprite unlit;
	[SerializeField] private Sprite lit;
	private SpriteRenderer m_spriteRen;
	protected void Awake()
	{
		m_spriteRen.sprite = unlit;
	}

	public void LanternOn()
	{
		m_spriteRen.sprite = lit;
	}
}
