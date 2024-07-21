using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private float decay;
    [SerializeField] private Bullet bulletConfig;
    public static event Action OnOnMouseDown;

    private void Awake() {
        bulletConfig = GetComponent<Bullet>();
    }

    void Update()
    {
        if (bulletConfig.enabled == false) {
            decay -= 1*Time.deltaTime;
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
