using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPlacer : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.position = Input.mousePosition;
    }
}
