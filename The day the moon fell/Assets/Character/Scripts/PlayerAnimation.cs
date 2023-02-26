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

	// Start is called before the first frame update
	void Awake()
    {
		m_Input = GetComponent<PlayerInput>();
		m_Animator= GetComponent<Animator>();
		m_Input.currentActionMap.FindAction("Movement").performed += MoveStart;
		m_Input.currentActionMap.FindAction("Movement").canceled += MoveEnd;
	}

	void MoveStart(InputAction.CallbackContext context)
	{
		//set walk to true
		if (m_direction != context.ReadValue<Vector2>())
		{
			Flip();
			m_direction = context.ReadValue<Vector2>();
			m_Animator.SetBool("Walk", true);
			m_Animator.SetBool("Idle", false);
		}
	}

	void MoveEnd(InputAction.CallbackContext context)
	{
		m_Animator.SetBool("Idle", true);
		m_Animator.SetBool("Walk", false);
	}


	// Update is called once per frame
	void Flip()
    {
		Vector3 theScale = transform.localScale;

		if (m_direction.x > 0)
		{
			theScale.x = -1f;
		}
		if (m_direction.x <= 0)
		{
			theScale.x = 1f;
		}

		transform.localScale = theScale;
	}
}
