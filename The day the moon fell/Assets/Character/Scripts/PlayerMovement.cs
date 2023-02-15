using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


[RequireComponent(typeof(PlayerInput))]

public class PlayerMovement : MonoBehaviour
{
	private PlayerInput m_Input;
	private Rigidbody2D m_Rigidbody;
	private Vector2 m_Movement;
	void Awake()
	{
		m_Input = GetComponent<PlayerInput>();
		m_Rigidbody = GetComponent<Rigidbody2D>();
		m_Input.currentActionMap.FindAction("Movement").performed += Handle_Movement_Performed;
		//m_Input.currentActionMap.FindAction("Jump").performed += Handle_Jump_Performed;
		//m_Input.currentActionMap.FindAction("Movement").canceled += Handle_Movement_Cancelled;
	}

	#region movementHandling
	void Handle_Movement_Performed(InputAction.CallbackContext context)
	{
		m_Movement = context.ReadValue<Vector2>();
		//movement coroutine 
	}
	#endregion

	#region movement 

	#endregion
}
