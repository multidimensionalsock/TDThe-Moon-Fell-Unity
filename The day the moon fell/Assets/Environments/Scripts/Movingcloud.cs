using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Movingcloud : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField] GameObject point1;
	[SerializeField] GameObject point2;
	[SerializeField] float speed;
	private Vector2 movement;
    void Start()
    {
		point1.GetComponent<SpriteRenderer>().enabled= false;
		point2.GetComponent<SpriteRenderer>().enabled= false;
		Vector2 move =  point1.transform.position - gameObject.transform.position;
		move.Normalize();
		movement = move * speed;

	}

    // Update is called once per frame
    void FixedUpdate()
    {
		//if not at position
		//keep moving then end update 
		//else
		//change target to other and change the direction speed to the opposite vector 2 direction 
		//or do it on collision?
		
		gameObject.transform.position = new Vector2(gameObject.transform.position.x + movement.x, gameObject.transform.position.y + movement.y);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == point1)
		{
			Vector2 move = point2.transform.position - gameObject.transform.position;
			move.Normalize();
			movement = move * speed;
		}
		if (collision.gameObject == point2)
		{
			Vector2 move = point1.transform.position - gameObject.transform.position;
			move.Normalize();
			movement = move * speed;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("collidgn");
	}
}
