using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhotoItemUIscript : MonoBehaviour
{
	// Start is called before the first frame update
	PlayerInput m_input;
	GameObject m_player;
    void Start()
    {
        m_input= GetComponent<PlayerInput>();
    }

	private void Update()
	{
		if (Input.anyKeyDown)
			End();
	}

	// Update is called once per frame
	void End()
    {
		//yield return new WaitForSeconds(1f);
		//while (Input.anyKey == false)
		//{
		//	yield return new WaitForFixedUpdate();
		//}
		m_player.GetComponent<PlayerMovement>().enabled = true;
		Destroy(gameObject.transform.parent.gameObject);
    }

	public void setplayer(GameObject player)
	{
		m_player= player;
		
	}
}
