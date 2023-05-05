using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]

//need an event system to set if colliding for fire light 
public class PlayerAnimation : MonoBehaviour
{
	private PlayerInput m_Input;
	private Vector2 m_direction; //true == right, false == left
	private Animator m_Animator;
	private bool m_Running;
	private bool m_LanternCollision;
	//state 0 = idle
	//state 1 = walk
	//state 2 = running
	//state 3 = light 

	// Start is called before the first frame update
	void Awake()
	{
		m_Input = GetComponent<PlayerInput>();
		m_Animator = GetComponent<Animator>();
		m_Input.currentActionMap.FindAction("Movement").performed += MoveStart;
		m_Input.currentActionMap.FindAction("Movement").canceled += MoveEnd;
		m_Input.currentActionMap.FindAction("Run").performed+= RunStart;
		m_Input.currentActionMap.FindAction("Run").canceled+= RunEnd;
		m_Input.currentActionMap.FindAction("Lantern").performed += Light;
		//e to run
	}

	void MoveStart(InputAction.CallbackContext context)
	{
		//set walk to true
		if (m_Running != true)
		{
			m_Animator.SetInteger("State", 1);
		}
		if (m_direction != context.ReadValue<Vector2>())
		{
			Flip();
			m_direction = context.ReadValue<Vector2>();
			
		}
	}

	void MoveEnd(InputAction.CallbackContext context)
	{
		m_Animator.SetInteger("State", 0);
	}

	void RunStart(InputAction.CallbackContext context)
	{
		m_Running= true;
		m_Animator.SetInteger("State", 2);
	}

	void RunEnd(InputAction.CallbackContext context)
	{
		m_Running= false;
		m_Animator.SetInteger("State", 0);
	}

	void Light(InputAction.CallbackContext context)
	{
		if (m_LanternCollision == true)
		{
			m_Animator.SetInteger("State", 3);
		}
		StartCoroutine(EndLight());

	}

	IEnumerator EndLight()
	{
		yield return new WaitForSeconds(0.2f);
		m_Animator.SetInteger("State", 0);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Lantern")
		{
			m_LanternCollision = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Lantern")
		{
			m_LanternCollision = false;
		}
	}

	// Update is called once per frame
	void Flip()
	{
		Vector3 theScale = transform.localScale;

		if (m_direction.x > 0)
		{
			theScale.x = -5f;
		}
		if (m_direction.x <= 0)
		{
			theScale.x = 5f;
		}

		transform.localScale = theScale;
	}
}