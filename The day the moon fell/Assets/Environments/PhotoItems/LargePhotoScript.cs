using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LargePhotoScript : MonoBehaviour
{
    // Start is called before the first frame update
    Lantern[] childObjects;
    int noLanterns;
    int lanternsLit = 0;
    [SerializeField] int photoNumber;
    [SerializeField] GameObject phototracker;
    private Image m_renderer;
    private void Start()
    {
        phototracker = GameObject.Find("PhotoTracker");
		if (phototracker != null)
		{
			m_renderer = GetComponent<Image>();
			if (phototracker.GetComponent<PhotoItemTracker>().GetIfTrue(photoNumber) == true)
			{
				
				m_renderer.enabled = true;
			}
			else
			{
				m_renderer.enabled = false;
			}
		}
		
		//childObjects = GetComponentsInChildren<Lantern>();
		//noLanterns= transform.childCount;
		//Debug.Log("child obj " + noLanterns);
        
    }

 //   private void AddLantern()
 //   {
	//	int childObjectsLit = 0;
	//	for (int i = 0; i < childObjects.Length; i++)
	//	{
	//		if (childObjects[i].LanternIsOn == true)
	//		{
	//			childObjectsLit++;
				
	//		}
	//	}
	//	if (childObjectsLit > 0)
	//	{
	//		Debug.Log("lantenrs lit is " + (noLanterns / childObjectsLit));
	//		Color newColor = new Color(1f, 1f, 1f, m_renderer.color.a + (1f / ((float)noLanterns / (float)childObjectsLit)));
	//		m_renderer.color = newColor;
	//	}

	//}
}
