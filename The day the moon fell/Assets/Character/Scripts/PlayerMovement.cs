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
	private Coroutine m_moveCoroutine;

	[Header("Movement variables")]
	[SerializeField] float m_movementSpeed;
	void Awake()
	{
		m_Input = GetComponent<PlayerInput>();
		m_Rigidbody = GetComponent<Rigidbody2D>();
		m_Input.currentActionMap.FindAction("Movement").performed += MoveStart;
		//m_Input.currentActionMap.FindAction("Jump").performed += Jump;
		m_Input.currentActionMap.FindAction("Movement").canceled += MoveEnd;
	}

	#region movementHandling
	void MoveStart(InputAction.CallbackContext context)
	{
		m_Movement = context.ReadValue<Vector2>();
		m_moveCoroutine = StartCoroutine(Move());
	}

	void MoveEnd(InputAction.CallbackContext context)
	{
		m_Movement = Vector2.zero;
		StopCoroutine(m_moveCoroutine);
	}

	#endregion

	#region movement 
	IEnumerator Move()
	{
		while (m_Movement != Vector2.zero)
		{
			m_Rigidbody.AddForce(m_Movement * m_movementSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);

			yield return new WaitForFixedUpdate();
		}
	}

	#endregion
}
