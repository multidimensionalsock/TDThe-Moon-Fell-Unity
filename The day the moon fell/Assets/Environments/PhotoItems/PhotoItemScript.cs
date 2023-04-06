using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoItemScript : MonoBehaviour
{
	public static event System.Action<int> ItemCollected;
	[SerializeField] int itemNo;
	
	void Start()
    {
		gameObject.transform.GetChild(0).gameObject.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
		ItemCollected?.Invoke(itemNo);
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.transform.GetChild(0).gameObject.GetComponent<PhotoItemUIscript>().setplayer(collision.gameObject);
		gameObject.transform.GetChild(0).gameObject.SetActive(true);
	}
}
