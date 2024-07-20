using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlantPlacer : MonoBehaviour
{
    [SerializeField] private MouseLocator mouseLocator;
    [SerializeField] private GameObject plantPrefab;

    void Start()
    {
        Tile.OnOnMouseDown += TileClicked;
    }

    void Update()
    {
        transform.position = mouseLocator.GetMousePosition();
    }

    private void TileClicked() {
        Instantiate(plantPrefab, transform.position, quaternion.identity);
        Tile.OnOnMouseDown -= TileClicked;
        Destroy(gameObject);
    }

    private void VerifyCancel() {
        
    }
}
