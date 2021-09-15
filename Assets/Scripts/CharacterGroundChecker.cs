using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroundChecker : MonoBehaviour
{

    public bool IsGrounded { get; private set; }


    private void Update()
    {
        if (transform.position.y < -4f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            IsGrounded = false;
        }
    }
}
