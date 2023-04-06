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
		m_input.currentActionMap.FindAction("Next").performed += End;
    }

    // Update is called once per frame
    void End(InputAction.CallbackContext context)
    {
		m_player.GetComponent<PlayerMovement>().enabled = true;
		Destroy(gameObject.transform.parent.gameObject);
    }

	public void setplayer(GameObject player)
	{
		m_player= player;
		
	}
}
