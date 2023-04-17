using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargePhotoScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] childObjects;
    int noLanterns;
    int lanternsLit = 0;
    [SerializeField] int photoNumber;
    [SerializeField] GameObject phototracker;
    private SpriteRenderer m_renderer;
    private void Start()
    {
        noLanterns = childObjects.Length + 1;
        phototracker = GameObject.Find("PhotoTracker");
        if (phototracker.GetComponent<PhotoItemTracker>().GetIfTrue(photoNumber) == true)
        {
            Lantern.LanternLit += AddLantern;
        }
        m_renderer = GetComponent<SpriteRenderer>();
        
    }

    private void AddLantern()
    {
        lanternsLit++;
        Color newColor = new Color(1f, 1f, 1f, m_renderer.color.a + (1f/ noLanterns));
        m_renderer.color = newColor;

    }
}
