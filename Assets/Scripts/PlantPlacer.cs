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
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private GameObject plantInstantiated;
    private Vector2 centerPosition;
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

    /// <summary>
    /// Se não houver uma planta no tile, Instancia a planta no centro dele e passa o gridManager para ela,
    /// notifica o grid que a planta foi plantada e dispara o evento avisando. Se houver, dispara o evento cancelando.
    /// </summary>
    private void TileClicked() {
        if (VerifyCancel()) {
            centerPosition.x = mouseLocator.GetGridPosition().x + xOffset;
            centerPosition.y = mouseLocator.GetGridPosition().y + yOffset;
            plantInstantiated = Instantiate(plantPrefab, centerPosition, quaternion.identity);
            plantInstantiated.GetComponent<Plants>().SetGridManager(gridManager);
            gridManager.Planted();
            OnPlantPlaced?.Invoke();
        } else {
            OnCancelBuy?.Invoke();
        }
        Tile.OnOnMouseDown -= TileClicked;
        Destroy(gameObject);
    }

    /// <summary>
    /// Checa se há uma planta na célula clicada
    /// </summary>
    /// <returns>True caso encontre uma planta, false caso contrário</returns>
    private bool VerifyCancel() {
        if (gridManager.CheckPlantSlot() == 0) {
            return true;
        } else {
            return false;
        }
    }
}
