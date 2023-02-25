using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] GameObject ToFollow;
	[SerializeField] float yoffset;
	[SerializeField] float xoffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ToFollow.transform.position.x + xoffset, ToFollow.transform.position.y + yoffset, transform.position.z);
    }
}
