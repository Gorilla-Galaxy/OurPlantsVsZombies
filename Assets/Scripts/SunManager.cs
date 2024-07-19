using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    [SerializeField] private int sunCount;
    [SerializeField] private TMP_Text sunCountPlayer;
    [SerializeField] private int sunPower;

    private void Awake() {
        sunPower = 25;
    }

    void Start()
    {
        AddSunCount();
        Sun.OnOnMouseDown += AddSunCount;
    }

    void Update()
    {
        
    }

    private void UpdateSunCount() {
        sunCountPlayer.text = sunCount.ToString();
    }

    private void AddSunCount() {
        sunCount += sunPower;
        UpdateSunCount();
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
    }
}
