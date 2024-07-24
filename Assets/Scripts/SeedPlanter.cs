using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SeedPlanter : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private SunManager sunManager;
    [SerializeField] private GameObject prefabPlant;
    [SerializeField] private KeyCode atalho;
    public static event Action OnPlantBought;
    [Header("Cooldown")]
    [SerializeField] private float timerCooldownPlant;
    [SerializeField] private float timerPlant;
    [SerializeField] private bool buyableStart; //Se a planta pode ser comprada no início do jogo ou tem que esperar o cooldown 
    [SerializeField] private Image imageCooldown;
    [SerializeField] private bool compra; // Armazena o retorno do método SunManager.BuyPlant()
    [SerializeField] private bool origin = false; // Verifica se a origem do evento vem desse script

    void Start()
    {
        if (buyableStart){
            imageCooldown.fillAmount = 0;
            timerCooldownPlant = 0;
        } else {
            imageCooldown.fillAmount = 1f;
            timerCooldownPlant = timerPlant;
        }
    }

    void Update()
    {   
        if (timerCooldownPlant <= 0){
            timerCooldownPlant = 0;    
        } else {
            timerCooldownPlant -= Time.deltaTime;
            imageCooldown.fillAmount = timerCooldownPlant / timerPlant;
        }
        if (Input.GetKeyDown(atalho)) {
            TryBuyPlant();
        }
    }

    [ContextMenu("Try Buy Plant")]
    public void TryBuyPlant() {
        compra = sunManager.BuyPlant(cost);
        if (compra && timerCooldownPlant == 0) {
            Instantiate(prefabPlant, Input.mousePosition, Quaternion.identity);
            origin = true;
            OnPlantBought?.Invoke();
            PlantPlacer.OnCancelBuy += CancelBuy;
            PlantPlacer.OnPlantPlaced += PlantPlaced;
        }
        if(timerCooldownPlant > 0){
            if (!compra) {
            } else sunManager.UndoBuy(cost);
        }
    }

    private void CancelBuy() {
        sunManager.UndoBuy(cost);
        PlantPlaced();
    }

    private void PlantPlaced() {
        PlantPlacer.OnCancelBuy -= CancelBuy;
        PlantPlacer.OnCancelBuy -= PlantPlaced; 
        if (origin) {
            timerCooldownPlant = timerPlant;
            origin = false;
        }
    }
}
