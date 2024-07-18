using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    [SerializeField] private int life, damage;
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private GameObject maxDistance;
    [SerializeField] private float distance;
    
    void Start()
    {
        distance = (float)maxDistance.transform.position.x;
    }
    void Update()
    {
        CheckForColliders();
    }

    public void CheckForColliders(){

        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.right, distance, 1<<10);

        if (ray){
            Debug.Log(" Acertou poura");
        }
    }


}
