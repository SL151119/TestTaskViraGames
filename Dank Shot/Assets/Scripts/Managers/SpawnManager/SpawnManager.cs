using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // [Header("Game Data:")]
    //  [SerializeField] GameplayData _data;
    //private GameObject _selectedBasket;
    // [SerializeField] private ScoreController scoreManager;

    public static SpawnManager Instance { get; private set; }

    public List<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        GetPooledObject().SetActive(true);
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    /* private void CalculateDifficulty()
     {
         if (scoreManager._score < 100)
         {
             _selectedBasket = _data.GetEasy;
         }
             else if ( ... )
         {
             _selectedBasket = _data.GetNormal;
         }
         else if ( ... )
         {
             _selectedBasket = _data.GetHard;
         }
         else
         {
             _selectedBasket = _data.GetExpert;
         } 
     }*/
}
