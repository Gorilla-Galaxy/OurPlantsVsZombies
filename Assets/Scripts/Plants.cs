using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Plants : MonoBehaviour
{
    [SerializeField] private int life, damage;
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private GameObject shootRange;
    [SerializeField] private float distance;
    [SerializeField] private float timeBTBullets;
    [SerializeField] private float timer;
    [SerializeField] private Vector3 bulletSpawnOffset;
    
    void Start()
    {
        distance = shootRange.transform.position.x - transform.position.x;
    }

    void Update()
    {
        CheckForColliders();
        if (timer < timeBTBullets) {
            timer += 1*Time.deltaTime;
        }   else if (CompareTag("Sunflower")){
            bulletSpawnOffset.x = UnityEngine.Random.Range(-0.4f, 0.4f);
            Fire();
        }
    }

    public void CheckForColliders(){

        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.right, distance, 1<<10);

        if (ray){
            Fire();
        }
    }

    private void Fire() {
        if (timer >= timeBTBullets) {
            Instantiate(bulletPrefab, transform.position + bulletSpawnOffset, quaternion.identity);
            timer = 0;
        }
    }

    public int GetDamage() {
        return damage;
    }

    public int GetHp() {
        return life;
    }

    public void DamagePlants(int damage) {
        life -= damage;
    }

    public void MataPlanta() {
        Destroy(gameObject);
    }
}
