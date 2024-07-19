using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SeedPlanter : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private SunManager sunManager;
    [SerializeField] private GameObject prefabPlant;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    [ContextMenu("Try Buy Plant")]
    public void TryBuyPlant() {
        if (sunManager.BuyPlant(cost)) {
            Instantiate(prefabPlant, Input.mousePosition, Quaternion.identity);
        }
    }
}
