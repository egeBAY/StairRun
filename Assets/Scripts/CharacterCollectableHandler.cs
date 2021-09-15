using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollectableHandler : MonoBehaviour
{
    
    public int numberOfStairs;
    [SerializeField] private GameObject backPackStairPrefab;
    [SerializeField] public Transform backPackStairPos;
    private List<GameObject> backStairs;


    private void Awake()
    {
        backStairs = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "stairs")
        {
            
            AddToBackPack(other.transform.childCount);
            Destroy(other.gameObject);
            Debug.Log("Triggered");
        }

    }

    private void AddToBackPack(int number)
    {
        for (int i = 0; i < number; i++)
        {
            var backStair = Instantiate(backPackStairPrefab, backPackStairPos);
            backStair.transform.position += Vector3.up * 0.15f * numberOfStairs;
            backStairs.Add(backStair);
            numberOfStairs++;
        }
    }

    public void RemoveStair()
    {
        Destroy(backStairs[backStairs.Count - 1]);
        backStairs.RemoveAt(backStairs.Count - 1);
        numberOfStairs--;
    }


}
