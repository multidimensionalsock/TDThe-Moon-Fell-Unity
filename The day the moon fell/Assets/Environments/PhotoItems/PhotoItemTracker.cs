using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoItemTracker : MonoBehaviour
{
	// Start is called before the first frame update
	public bool[] itemsCollected = { false, false, false, false, false, false, false, false, false, false, false };
    void Start()
    {
		DontDestroyOnLoad(this);
		PhotoItemScript.ItemCollected += SetTrue;
    }

    void SetTrue(int itemNo)
	{
		itemsCollected[itemNo] = true;
	}

	public bool GetIfTrue(int objectNo)
    {
		if (itemsCollected[objectNo] == true)
        {
			return true;
        }
		return false;
    }
}
