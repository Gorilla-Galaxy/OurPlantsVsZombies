using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private float decay;
    [SerializeField] private BulletSunflower bulletConfig;
    [SerializeField] private Vector2 previousPosition;
    [SerializeField] private float maxSunDistance;
    [SerializeField] private float sunRedutor;
    public static event Action OnOnMouseDown;

    private void Awake() {
        bulletConfig = GetComponent<BulletSunflower>();
        maxSunDistance = UnityEngine.Random.Range(4, 6);
        previousPosition = transform.position;
    }

    private void FixedUpdate() {
        Fall();
    }

    void Update()
    {
        Disappear();
    }

    private void OnMouseEnter() {
        OnOnMouseDown?.Invoke();
        Destroy(gameObject);
    }

    /// <summary>
    /// Reduce the size of the sun, then deletes it
    /// </summary>
    private void Disappear()
    {
        if (bulletConfig.enabled == false)
        {
            decay -= 0.8f * Time.deltaTime;
            transform.localScale -= transform.localScale * Time.deltaTime / sunRedutor;
            if (decay < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Fall()
    {
        if (bulletConfig.enabled == true)
        {
            maxSunDistance -= Vector2.Distance(transform.position, previousPosition);
            previousPosition = transform.position;
            if (maxSunDistance < 0)
            {
                bulletConfig.SetSunState(false);
            }
        }
    }
}
