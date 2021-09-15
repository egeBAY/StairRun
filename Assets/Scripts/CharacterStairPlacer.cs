using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStairPlacer : MonoBehaviour
{
    public int defaultStairs = 5;
    public float stairCd = 0.1f;
    private bool canPlace = true;
    private bool canPickUp;
    [SerializeField] private Stair stairPrefab;
    private CharacterGroundChecker groundChecker;
    private CharacterCollectableHandler characterCollectableHandler;
    private Rigidbody rb;
    Vector3 lastVelocity;
    float timer = 0f;


    private void Awake()
    {
        groundChecker = GetComponent<CharacterGroundChecker>();
        rb = GetComponent<Rigidbody>();
        characterCollectableHandler = GetComponent<CharacterCollectableHandler>();
    }

    private void Update()
    {
        lastVelocity = rb.velocity;

        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            if(canPlace)
            { 
                makeStairs();
            }

            if(timer > stairCd)
            {
                timer = 0f;
                canPlace = true;
            }
        }

        else if(Input.GetMouseButtonUp(0) && !groundChecker.IsGrounded)
        {
            rb.isKinematic = false;
            canPlace = true;
            timer = 0f;
        }

        if (groundChecker.IsGrounded)
        {
            rb.isKinematic = true;
        }
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9)
        {
            Debug.Log("Obstacle!!!");
            rb.isKinematic = false;
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 12f);
        }
    }

*/
    private void makeStairs()
    {
        if (characterCollectableHandler.numberOfStairs > 0)
        {
            rb.isKinematic = true;
            var stair = Instantiate(stairPrefab);
            stair.transform.position = transform.position;
            transform.position += Vector3.up * 0.5f;
            characterCollectableHandler.RemoveStair();
            canPlace = false;

        }
        else
            rb.isKinematic = false; 
    }

}
