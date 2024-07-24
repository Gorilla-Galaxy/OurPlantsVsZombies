using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private float decay;
    [SerializeField] private Bullet bulletConfig;
    [SerializeField] private Vector2 previousPosition;
    [SerializeField] private float maxSunDistance;
    [SerializeField] private float sunRedutor;
    public static event Action OnOnMouseDown;

    private void Awake() {
        bulletConfig = GetComponent<Bullet>();
        maxSunDistance = UnityEngine.Random.Range(4, 6);
        previousPosition = transform.position;
    }

    private void FixedUpdate() {
        if (bulletConfig.enabled == true) {
            maxSunDistance -= Vector2.Distance(transform.position, previousPosition);
            previousPosition = transform.position;
            if (maxSunDistance < 0) {
                bulletConfig.SetSunState(false);
            }
        }
    }

    void Update()
    {
        if (bulletConfig.enabled == false) {
            decay -= 0.8f*Time.deltaTime;
            transform.localScale -= transform.localScale*Time.deltaTime/sunRedutor;
            if (decay < 0) {
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseEnter() {
        OnOnMouseDown?.Invoke();
        Destroy(gameObject);
    }
}
