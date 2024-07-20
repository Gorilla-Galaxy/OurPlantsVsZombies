using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public static event Action OnOnMouseDown;

    private void OnMouseDown() {
        OnOnMouseDown?.Invoke();
    }

    private void OnMouseEnter() {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnMouseExit() {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
