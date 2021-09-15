using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionHandler : MonoBehaviour
{
    public event Action OnObstacleCollided;

    CharacterCollectableHandler characterCollectableHandler;
    GameManager gameManager;

    private void Awake()
    {
        characterCollectableHandler = GetComponent<CharacterCollectableHandler>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            if(OnObstacleCollided != null)
            {
                OnObstacleCollided.Invoke();

                if(characterCollectableHandler.numberOfStairs <= 0)
                {
                    gameManager.GameOver();
                }
            }
        }
    }


}
