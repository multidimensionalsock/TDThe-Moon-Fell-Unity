using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCollisions : MonoBehaviour
{
	private PlayerInput m_Input;
	private Vector2 m_direction; //true == right, false == left
	private bool lampCollision;
	private GameObject currentLamp;

	// Start is called before the first frame update
	void Awake()
	{
		m_Input = GetComponent<PlayerInput>();
		//m_Input.currentActionMap.FindAction("Lantern").performed += LightLamp();
		m_Input.currentActionMap.FindAction("Lantern").performed += LightLamp();
	}

	void LightLamp(InputAction.CallbackContext context)
	{
		if (lampCollision == true)
		{
			currentLamp.GetComponent<Lantern>().LanternOn();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "lamp")
		{
			lampCollision= true;
			currentLamp = collision.gameObject;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "lamp")
		{
			lampCollision = false;
			currentLamp = null;
		}
	}
}
