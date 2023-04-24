using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternEvents : MonoBehaviour
{
	public int LanternsLit = 0;
	[SerializeField] int LanternsInLevel = 0;
	bool AllLit = false;
	public bool ProceedToNextLevel() { return AllLit; }

    // Start is called before the first frame update
    void Start()
    {
		Lantern.LanternLit += AddLantern;
    }

	void AddLantern()
	{
		LanternsLit++;
		Debug.Log(LanternsLit >= LanternsInLevel);
		if (LanternsLit >= LanternsInLevel)
		{
			AllLit = true;
		}
	}
   
}
