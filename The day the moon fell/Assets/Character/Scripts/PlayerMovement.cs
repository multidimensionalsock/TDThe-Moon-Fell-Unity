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
	[SerializeField] float m_maxVelocity;
	[SerializeField] float m_jumpForce;

	void Awake()
	{
		m_Input = GetComponent<PlayerInput>();
		m_Rigidbody = GetComponent<Rigidbody2D>();
		m_Input.currentActionMap.FindAction("Movement").performed += MoveStart;
		m_Input.currentActionMap.FindAction("Jump").performed += Jump;
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
		Debug.Log("moving");
		while (m_Movement.x != 0)
		{
			m_Rigidbody.AddForce(new Vector2(m_Movement.x * m_movementSpeed * Time.fixedDeltaTime, 0), ForceMode2D.Impulse);

			if (m_Rigidbody.velocity.x > m_maxVelocity)
            {
				m_Rigidbody.velocity = new Vector2(m_maxVelocity, m_Rigidbody.velocity.y);
			}
			yield return new WaitForFixedUpdate();
		}
	}

	void Jump(InputAction.CallbackContext context)
    {
		Debug.Log("jumping");
		//need to check gounded
		m_Rigidbody.AddForce(new Vector2(0, m_jumpForce), ForceMode2D.Impulse);
	}

	#endregion
}
