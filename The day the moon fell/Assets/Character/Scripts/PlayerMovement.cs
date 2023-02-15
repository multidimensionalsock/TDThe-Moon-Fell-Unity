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
	void Awake()
	{
		m_Input = GetComponent<PlayerInput>();
		m_Rigidbody = GetComponent<Rigidbody2D>();
		m_Input.currentActionMap.FindAction("Movement").performed += Handle_Movement_Performed;
		m_Input.currentActionMap.FindAction("Jump").performed += Handle_Jump_Performed;
		m_Input.currentActionMap.FindAction("Movement").canceled += Handle_Movement_Cancelled;
		m_Input.currentActionMap.FindAction("Jump").canceled += Handle_Jump_Cancelled;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
