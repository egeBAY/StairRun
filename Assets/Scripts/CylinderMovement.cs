using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.AddForce(Vector3.right * 200f);
            Debug.Log("Player Girdi");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        
    }

}
