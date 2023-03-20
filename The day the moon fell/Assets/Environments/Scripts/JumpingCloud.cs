using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingCloud : MonoBehaviour
{
    [SerializeField] float jumpEffector;
    // Start is called before the first frame update
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jumpEffector, 0), ForceMode2D.Impulse);
    }

    
}
