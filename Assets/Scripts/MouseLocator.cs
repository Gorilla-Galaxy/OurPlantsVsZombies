using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseLocator : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector2 mousePositionVector;
    [SerializeField] private float rayDistance;
    [SerializeField] private Vector2 gridPosition;
    [SerializeField] private GridManager gridManager;

    private void Awake() {
        mainCamera = Camera.main;
        rayDistance = 10;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        TransformScreenToWorldSpace(Input.mousePosition);
        CheckRayColliders();
    }
    
    private void TransformScreenToWorldSpace(Vector2 screenPosition) {
        mousePositionVector = mainCamera.ScreenToWorldPoint(new Vector2(screenPosition.x, screenPosition.y));
    }

    private void CheckRayColliders() {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, GetMousePosition(), rayDistance, 1<<8);
        if (ray) {
            gridManager = ray.transform.GetComponent<GridManager>();
            gridPosition = ray.transform.position;
        }
    }

    public Vector2 GetMousePosition() {
        return mousePositionVector;
    }

    public Vector2 GetGridPosition() {
        return gridPosition;
    }

    public GridManager GetGridGameObject() {
        return gridManager;
    }
}
