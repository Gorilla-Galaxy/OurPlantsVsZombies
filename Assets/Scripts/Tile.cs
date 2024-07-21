using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private bool highlightActive;
    [SerializeField] private int plantCount;
    public static event Action OnOnMouseDown;

    private void Start() {
    }

    private void Update() {
        if (CheckHighlight()) {
            sprite.enabled = true;
        } else {
            sprite.enabled = false;
        }
    }

    private bool CheckHighlight() {
        return highlightActive;
    }

    private void OnMouseEnter() {
        highlightActive = true;
    }

    private void OnMouseExit() {
        highlightActive = false;
    }

    private void OnMouseDown() {
        OnOnMouseDown?.Invoke();
    }

    public void PlantCountUp() {
        plantCount++;
        sprite.color = new Vector4 (1, 0, 0, 0.8f); // RGB Alfa - Red
    }

    public void PlantCountDown() {
        plantCount--;
        sprite.color = new Vector4 (1, 1, 1, 0.8f); // RGB Alfa - White
    }

    public int GetPlantCount() {
        return plantCount;
    }
}
