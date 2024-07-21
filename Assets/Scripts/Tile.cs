using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] gramas;
    [SerializeField] private int indexGrass;
    public static event Action OnOnMouseDown;

    private void Start() {
        indexGrass = UnityEngine.Random.Range(0, 7);
        spriteRenderer.sprite = gramas[indexGrass];
    }

    private void OnMouseDown() {
        OnOnMouseDown?.Invoke();
    }
}
