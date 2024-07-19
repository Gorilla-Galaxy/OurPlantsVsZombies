using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private float timeBTZombies;
    [SerializeField] private float timer;
    
    void Update()
    {
        if (timer < timeBTZombies) {
            timer += 1*Time.deltaTime;
        } else {
            SpawnZombie();
            }
    }

    public void SpawnZombie() {
        if (timer >= timeBTZombies) {
            Instantiate(zombie);
            timer = 0;
        }
    }
}
