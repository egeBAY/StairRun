using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;

public class CharacterPathFollow : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5f;
    private float setBackTime = 0.5f;
    private bool isObstacleCollided;
    float distanceTravelled;

    private void Awake()
    {
        GetComponentInChildren<CharacterCollisionHandler>().OnObstacleCollided += OnObstacleCollided;
    }

    private void OnObstacleCollided()
    {
        isObstacleCollided = true;
        speed = -15f;
        StartCoroutine("WaitForSetBack");
    }

    private IEnumerator WaitForSetBack()
    {
        yield return new WaitForSeconds(setBackTime);

        speed = 5f;
    }

    private void Update()
    {
        moveCharacter();
    }

    private void moveCharacter()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Loop);
    }


}
