
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
	private bool m_Running;
	private bool m_lighting;
	private bool m_grounded = true;
	private bool m_floorCollision = false;
	private List<GameObject> m_floor;
	public int jumpno = 0;
	Coroutine DontSlip = null;

	[Header("Movement variables")]
	[SerializeField] float m_movementSpeed;
	[SerializeField] float m_maxVelocity;
	public float m_jumpForce;
	[SerializeField] float m_runSpeed;

	void Awake()
	{
		m_Input = GetComponent<PlayerInput>();
		m_Rigidbody = GetComponent<Rigidbody2D>();
		m_Input.currentActionMap.FindAction("Movement").performed += MoveStart;
		m_Input.currentActionMap.FindAction("Jump").performed += Jump;
		m_Input.currentActionMap.FindAction("Movement").canceled += MoveEnd;
		m_Input.currentActionMap.FindAction("Run").performed += RunStart;
		m_Input.currentActionMap.FindAction("Run").canceled += RunEnd;
		m_Input.currentActionMap.FindAction("Lantern").performed += light;
		m_Input.currentActionMap.FindAction("Drop").performed += Drop;
		m_floor = new List<GameObject>();

	}

	private void Update()
	{
		if (Mathf.Abs(m_Rigidbody.velocity.y) <= 0.1f)
		{
			m_grounded = true;
		}
		//else if (m_floorCollision == true)
		//{
		//	m_grounded = true;
		//}
		else if (Mathf.Abs(m_Rigidbody.velocity.y) > 0.1f)
		{
			m_grounded = false;
		}

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
		if (m_Rigidbody.velocity.y == 0)
			m_Rigidbody.velocity = new Vector2(0, m_Rigidbody.velocity.y);
		//else
		//{
		//	StartCoroutine(CheckIfGrounded());
		//}
		StopCoroutine(m_moveCoroutine);
	}

	void Drop(InputAction.CallbackContext context)
	{
		Debug.Log(m_floor);
		for (int i = 0; i <= m_floor.Count; i++)
		{
			m_floor[i].GetComponent<ColliderController>().DisableCollider();
		}
		m_floor.Clear();
	}

	void RunStart(InputAction.CallbackContext context)
	{
		m_Running = true;
	}
	void RunEnd(InputAction.CallbackContext context)
	{
		m_Running = false;
	}
	void light(InputAction.CallbackContext context)
	{
		//if colliding with lantern
		StartCoroutine(EndLight());
	}

	IEnumerator EndLight()
	{
		m_lighting = true;
		yield return new WaitForSeconds(0.2f);
		m_lighting = false;
	}


	#endregion

	#region movement 
	//IEnumerator CheckIfGrounded()
	//{
	//	while (m_Rigidbody.velocity.y != 0)
	//	{
	//		m_grounded = false;
	//		yield return new WaitForFixedUpdate();
	//	}
	//	m_Rigidbody.velocity = Vector2.zero;
	//	m_grounded = true;
	//}
	IEnumerator Move()
	{
		if (m_lighting == true)
		{
			yield break;
		}
		while (m_Movement.x != 0)
		{
			if (m_Running == true)
			{
				m_Rigidbody.AddForce(m_Movement * m_runSpeed, ForceMode2D.Impulse);
			}
			else
			{
				m_Rigidbody.AddForce(m_Movement * m_movementSpeed, ForceMode2D.Impulse);
			}

			if (m_Rigidbody.velocity.x > m_maxVelocity)
			{
				m_Rigidbody.velocity = new Vector2(m_maxVelocity, m_Rigidbody.velocity.y);
			}
			else if (m_Rigidbody.velocity.x < -m_maxVelocity)
			{
				m_Rigidbody.velocity = new Vector2(-m_maxVelocity, m_Rigidbody.velocity.y);
			}
			yield return new WaitForFixedUpdate();
		}


	}



	void Jump(InputAction.CallbackContext context)
	{
		jumpno++;
		if (m_grounded == true)
		{
			jumpno = 0;
		}
		if (m_grounded == true || jumpno < 2)
		{
			m_Rigidbody.AddForce(new Vector2(0, m_jumpForce), ForceMode2D.Impulse);
			GetComponentInChildren<AudioSource>().Play();
			//StartCoroutine(CheckIfGrounded());
		}

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.tag == "Floor")
		{
			Debug.Log("colliding");
			m_floorCollision = true;
			Debug.Log(collision.gameObject);
			m_floor.Add(collision.gameObject);
		}

	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Floor")
		{
			m_floorCollision = false;
			m_floor.Remove(collision.gameObject);
		}
	}

	#endregion
}