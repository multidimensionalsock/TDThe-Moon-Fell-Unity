using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DissapearingPlatformScript : MonoBehaviour
{
	SpriteRenderer m_renderer;
	[SerializeField] float m_percentage;
	[SerializeField] float reduction;
	bool m_decreasing;
	BoxCollider2D m_collider;
    // Start is called before the first frame update
    void Start()
    {
        m_renderer= GetComponent<SpriteRenderer>();
		m_collider= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (m_decreasing)
		{
			m_percentage -= reduction;
			if (m_percentage <= 0)
			{
				m_decreasing = false;
			}
		}
		else
		{
			m_percentage += reduction;
			if (m_percentage >= 1f)
			{
				m_decreasing = true;
			}
		}
		Color newColour = new Color(1f, 1f, 1f, m_percentage);
		m_renderer.color = newColour;

		if (m_percentage < 0.25 && m_collider.enabled)
		{
			m_collider.enabled= false;
		}
		else if (m_percentage > 0.25 && !m_collider.enabled) 
		{ 
			m_collider.enabled= true;
		}
		
    }
}
