using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private void OnMouseEnter() {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnMouseExit() {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
