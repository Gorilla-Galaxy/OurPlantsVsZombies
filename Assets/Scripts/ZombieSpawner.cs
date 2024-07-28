using System;
using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private int qtdZumbisMortos = 0;
    [SerializeField] private float[] line;
    [SerializeField] private float timeBTZombies;
    
    
    void Awake()
    {
        timeBTZombies = 17f;
    }
    void Update()
    {    
        timeBTZombies -= Time.deltaTime;
        if (timeBTZombies < 0) {
            SpawnZombie();
            timeBTZombies = 17f;
        }
        Wave();
    }

    public void SpawnZombie() {
        int index = UnityEngine.Random.Range(0, 5);
        Instantiate(zombie, new Vector2 (transform.position.x, line[index]), Quaternion.identity);
        timeBTZombies -= Time.deltaTime;
    }
    public void Wave(){
        
        if (qtdZumbisMortos > 20) {
            timeBTZombies -= 10*Time.deltaTime;
        } else if (qtdZumbisMortos > 10) {
                timeBTZombies -= 4*Time.deltaTime;
            } else if (qtdZumbisMortos > 5) {
                timeBTZombies -= 2*Time.deltaTime;
            }
    }
    public void ZombieDead() {
        Debug.Log("Porra");
        qtdZumbisMortos++;
    }
}
