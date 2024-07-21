using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private float timeBTZombies;
    [SerializeField] private float timer;
    [SerializeField] private float[] line;
    
    void Update()
    {
        if (timer < timeBTZombies) {
            timer += 1*Time.deltaTime;
        } else {
            SpawnZombie();
            }
    }

    public void SpawnZombie() {
        int index = UnityEngine.Random.Range(0, 5);
        if (timer >= timeBTZombies) {
            Instantiate(zombie, new Vector2 (transform.position.x, line[index]), quaternion.identity);
            timer = 0;
        }
    }
}
