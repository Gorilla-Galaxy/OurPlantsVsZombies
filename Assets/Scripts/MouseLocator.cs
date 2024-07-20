using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocator : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector2 mousePositionVector;

    private void Awake() {
        mainCamera = Camera.main;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        TransformScreenToWorldSpace(Input.mousePosition);
    }
    
    private void TransformScreenToWorldSpace(Vector2 screenPosition) {
        mousePositionVector = mainCamera.ScreenToWorldPoint(new Vector2(screenPosition.x, screenPosition.y));
    }

    public Vector2 GetMousePosition() {
        return mousePositionVector;
    }
}
