using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    [SerializeField] private int life, damage;
    [SerializeField] private float walkSpeed;
    [SerializeField] private new Rigidbody2D rigidbody;

    private void Awake() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (life <= 0) Destroy(gameObject);
    }

    private void FixedUpdate() {
        Vector2 position = rigidbody.position;
        Vector2 translation = Time.fixedDeltaTime * walkSpeed * Vector2.left;
        rigidbody.MovePosition(position + translation);
    }

    public void DamageEnemy(int damage) {
        life -= damage;
    }
}
