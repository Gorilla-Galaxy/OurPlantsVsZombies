using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    [SerializeField] private int sunCount;
    [SerializeField] private TMP_Text sunCountPlayer;
    [SerializeField] private int[] sunPower;
    [SerializeField] private Sun sun;
    [SerializeField] private float timer;
    [SerializeField] private float sunTimer;

    private void Awake() {
        timer = 3;
        sunTimer = 5;
    }

    void Start()
    {
        AddSunCount(0);
        AddSunCount(0);
        AddSunCount(0);
        AddSunCount(0);
        Sun.OnOnMouseDown += SunCollected;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > sunTimer) {
            timer = 0;
            GetRandomTimer();
            FireSun();
        }
    }

    private void UpdateSunCount() {
        sunCountPlayer.text = sunCount.ToString();
    }

    private void AddSunCount(int sunIdex) {
        sunCount += sunPower[sunIdex];
        UpdateSunCount();
    }

    private void SunCollected() {
        AddSunCount(0);
    }

    private void GetRandomTimer() {
        sunTimer = UnityEngine.Random.Range(7, 15);
    }

    private void FireSun() {
        float xOffset = UnityEngine.Random.Range(-7, 7);
        Vector2 sunPosition = new Vector2 (transform.position.x + xOffset, transform.position.y);
        Instantiate(sun, sunPosition, Quaternion.identity);
    }

    public bool BuyPlant(int price) {
        if (price <= sunCount) {
            sunCount -= price;
            UpdateSunCount();
            return true;
        } else return false;
    }

    public void UndoBuy(int price) {
        sunCount += price;
        UpdateSunCount();
    }

}
