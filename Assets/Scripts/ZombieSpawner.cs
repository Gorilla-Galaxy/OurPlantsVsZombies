using System;
using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private float timer;
    [SerializeField] private float[] line;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    [SerializeField] private float timeBTZombies;
    
    void Awake()
    {
        RandomTimeSpawn();
    }
    void Update()
    {    
        timeBTZombies -= Time.deltaTime;
        if (timeBTZombies < 0) {
            SpawnZombie();
            RandomTimeSpawn();
        }
        timer += Time.deltaTime;
        Wave();
    }

    public void SpawnZombie() {
        int index = UnityEngine.Random.Range(0, 5);
        Instantiate(zombie, new Vector2 (transform.position.x, line[index]), Quaternion.identity);
        timeBTZombies -= Time.deltaTime;
    }

    public void RandomTimeSpawn(){
        timeBTZombies = UnityEngine.Random.Range(minTime, maxTime);
    }
    public void Wave(){
        if (timer > 100) {
            timeBTZombies -= 2*Time.deltaTime;
        } else if (timer > 50) {
            timeBTZombies -= 1*Time.deltaTime;
        }
    }
}
