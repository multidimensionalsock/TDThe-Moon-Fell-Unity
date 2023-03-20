using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] GameObject moon;
    SpriteRenderer moonRenderer;
    [SerializeField] float FadeAmount;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        moonRenderer = moon.GetComponent<SpriteRenderer>();
    }

    public void StartEndLevel()
    {
        //check if theres enough lanterns lit in lantern lir event system
        //if there is then 
        StartCoroutine(moonFade());
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    IEnumerator moonFade()
    {
        while (moonRenderer.color.a != 1) 
        {
            Debug.Log("moon fade");
            moonRenderer.enabled = true;
            moonRenderer.color = new Color(1f, 1f, 1f, moonRenderer.color.a + FadeAmount);
            yield return new WaitForFixedUpdate();
         }
        //move to next scene (end of story exposition and credits)
    }
}

//needs to check if all lanterns have been lit
//if so then it can be called 