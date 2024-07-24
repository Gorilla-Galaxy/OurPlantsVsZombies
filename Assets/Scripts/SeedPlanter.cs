using System;
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
    [SerializeField] private KeyCode atalho;
    public static event Action OnPlantBought;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(atalho)) {
            TryBuyPlant();
        }
    }

    [ContextMenu("Try Buy Plant")]
    public void TryBuyPlant() {
        if (sunManager.BuyPlant(cost)) {
            Instantiate(prefabPlant, Input.mousePosition, Quaternion.identity);
            OnPlantBought?.Invoke();
            PlantPlacer.OnCancelBuy += CancelBuy;
            PlantPlacer.OnPlantPlaced += PlantPlaced;
        }
    }

    private void CancelBuy() {
        sunManager.UndoBuy(cost);
        PlantPlaced();
    }

    private void PlantPlaced() {
        PlantPlacer.OnCancelBuy -= CancelBuy;
        PlantPlacer.OnCancelBuy -= PlantPlaced;
    }
}
