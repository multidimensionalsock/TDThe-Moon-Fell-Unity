using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerCollisions : MonoBehaviour
{
	private PlayerInput m_input;
	private Lantern currentLantern;
	void Awake()
    {
		
		m_input = GetComponent<PlayerInput>();
		m_input.currentActionMap.FindAction("Lantern").performed += LanternOn;
	}

	private void LanternOn(InputAction.CallbackContext context)
	{
		Debug.Log("collision action called");
		if (currentLantern != null)
		{
			currentLantern.LanternOn();
			if (currentLantern.GetComponent<EndGameScript>() != null)
            {
				currentLantern.GetComponent<EndGameScript>().StartEndLevel();
            }
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Lantern")
		{
			Debug.Log("lantern collision");
			currentLantern = collision.gameObject.GetComponent<Lantern>();
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Lantern")
		{
			currentLantern = null;
		}
	
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Moving cloud")
		{
			transform.parent = collision.transform;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Moving cloud")
		{
			Debug.Log("pass");
			transform.parent = null;
		}
	}

}
