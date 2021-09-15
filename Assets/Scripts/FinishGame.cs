using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour {

    CharacterCollectableHandler characterCollectableHandler;
    GameManager gameManager;
    CanvasHandler canvasHandler;
    private void Awake()
    {
        characterCollectableHandler = FindObjectOfType<CharacterCollectableHandler>();
        gameManager = FindObjectOfType<GameManager>();
        canvasHandler = FindObjectOfType<CanvasHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && characterCollectableHandler.numberOfStairs > 0)
        {
            for (int i = 0; i < characterCollectableHandler.numberOfStairs; i++)
            {
                other.transform.position = transform.GetChild(i).position;
                canvasHandler.WinText.text = "You are at P" + characterCollectableHandler.numberOfStairs;
                gameManager.WinState();
            }
        }
    }
}
