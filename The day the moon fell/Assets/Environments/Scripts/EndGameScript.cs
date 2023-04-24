using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
public class EndGameScript : MonoBehaviour
{
    [SerializeField] GameObject moon;
    SpriteRenderer moonRenderer;
    [SerializeField] float FadeAmount;
    [SerializeField] GameObject player;
    [SerializeField] GameObject camera;
    [SerializeField] float cameraRev;
    [SerializeField] GameObject lanternEvents;
    [SerializeField] GameObject largeText;
    // Start is called before the first frame update
    void Start()
    {
        moonRenderer = moon.GetComponent<SpriteRenderer>();
    }

    public void StartEndLevel()
    {
        //check if theres enough lanterns lit in lantern lir event system
        //if there is then 
        if (lanternEvents.GetComponent<LanternEvents>().ProceedToNextLevel() == true)
        {
            StartCoroutine(moonFade());
            player.GetComponent<PlayerInput>().enabled = false;
            
        }
        //else
        //{
        //	//display message saying not all lantners have been lit
        //}
    }

    IEnumerator moonFade()
    {
        while (moonRenderer.color.a <= 1) 
        {
            transform.GetChild(0).gameObject.SetActive(true);
            moonRenderer.enabled = true;
            moonRenderer.color = new Color(1f, 1f, 1f, moonRenderer.color.a + FadeAmount);
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z - cameraRev);
            yield return new WaitForFixedUpdate();
         }
        //display text on scene 
    }

}
