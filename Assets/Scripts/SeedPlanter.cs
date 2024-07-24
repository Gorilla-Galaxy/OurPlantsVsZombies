using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SeedPlanter : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private SunManager sunManager;
    [SerializeField] private GameObject prefabPlant;
    [SerializeField] private KeyCode atalho;
    public static event Action OnPlantBought;
<<<<<<< Updated upstream
=======
    [Header("Cooldown")]
    [SerializeField] private float timerCooldownPlant;
    [SerializeField] private float timerPlant;
    [SerializeField] private bool buyableStart; //Se a planta pode ser comprada no início do jogo ou tem que esperar o cooldown 
    [SerializeField] private Image imageCooldown;
    [SerializeField] private bool compra; // Armazena o retorno do SunManager.BuyPlant()
    [SerializeField] private bool origem = false; // Verifica a origem do evento de planta colocada
>>>>>>> Stashed changes

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(atalho)) {
            TryBuyPlant();
        }
    }

    [ContextMenu("Try Buy Plant")]
    public void TryBuyPlant() {
<<<<<<< Updated upstream
        if (sunManager.BuyPlant(cost)) {
            Instantiate(prefabPlant, Input.mousePosition, Quaternion.identity);
            OnPlantBought?.Invoke();
            PlantPlacer.OnCancelBuy += CancelBuy;
            PlantPlacer.OnPlantPlaced += PlantPlaced;
=======
        compra = sunManager.BuyPlant(cost);
        if (compra && timerCooldownPlant == 0) {
            Instantiate(prefabPlant, Input.mousePosition, Quaternion.identity);
            origem = true;
            OnPlantBought?.Invoke();
            PlantPlacer.OnCancelBuy += CancelBuy;
            PlantPlacer.OnPlantPlaced += PlantPlaced;
        }  
        if(timerCooldownPlant > 0){
            if (compra == false) {
            } else sunManager.UndoBuy(cost);
>>>>>>> Stashed changes
        }
    }

    private void CancelBuy() {
        sunManager.UndoBuy(cost);
        PlantPlaced();
    }

    private void PlantPlaced() {
        PlantPlacer.OnCancelBuy -= CancelBuy;
<<<<<<< Updated upstream
        PlantPlacer.OnCancelBuy -= PlantPlaced;
=======
        PlantPlacer.OnCancelBuy -= PlantPlaced; 
        if (origem) {
            timerCooldownPlant = timerPlant;
            origem = false;
        }      
>>>>>>> Stashed changes
    }
}
