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
