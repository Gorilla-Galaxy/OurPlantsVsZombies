using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tile tileScript;
    [SerializeField] private SpriteRenderer sprite;
    void Start()
    {
        SeedPlanter.OnPlantBought += HighlightTiles;
        Tile.OnOnMouseDown += DeactivateTiles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void HighlightTiles() {
        tileScript.enabled = true;
    }

    private void DeactivateTiles() {
        tileScript.enabled = false;
        sprite.enabled = false;
    }

    /// <summary>
    /// Verifica estado do grid e retorna um valor para cada caso
    /// </summary>
    /// <returns>
    /// 1 Caso tenha uma planta
    /// 0 Caso não tenha uma planta
    /// </returns>
    public int CheckPlantSlot() {
        if (tileScript.GetPlantCount() > 0) {
            return 1;
        } else {
            return 0;
        }
    }

    public void Planted() {
        tileScript.PlantCountUp();
    }
}
