using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
	// Start is called before the first frame update
	BoxCollider2D m_collider;
    void Start()
    {
        m_collider= GetComponent<BoxCollider2D>();
    }

    public void DisableCollider()
	{
		m_collider.enabled = false;
		StartCoroutine(TurnOnCollider());
	}

	IEnumerator TurnOnCollider()
	{
		yield return new WaitForSeconds(0.5f);
		m_collider.enabled = true;
	}
}
