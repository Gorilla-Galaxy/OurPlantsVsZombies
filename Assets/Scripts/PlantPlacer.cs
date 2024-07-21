using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlantPlacer : MonoBehaviour
{
    [SerializeField] private MouseLocator mouseLocator;
    [SerializeField] private GameObject plantPrefab;
    [SerializeField] private GridManager gridManager;
    public static event Action OnCancelBuy;
    public static event Action OnPlantPlaced;

    void Start()
    {
        Tile.OnOnMouseDown += TileClicked;
    }

    void Update()
    {
        transform.position = mouseLocator.GetMousePosition();
        gridManager = mouseLocator.GetGridGameObject();
    }

    private void TileClicked() {
        if (VerifyCancel()) {
            Instantiate(plantPrefab, mouseLocator.GetGridPosition(), quaternion.identity);
            gridManager.Planted();
            OnPlantPlaced?.Invoke();
        } else {
            OnCancelBuy?.Invoke();
        }
        Tile.OnOnMouseDown -= TileClicked;
        Destroy(gameObject);
    }

    private bool VerifyCancel() {
        if (gridManager.CheckPlantSlot() == 0) {
            return true;
        } else {
            return false;
        }
    }
}
