using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    [SerializeField] private int life, damage;
    [SerializeField] private float walkSpeed;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float fixedSpeed = 0.3f;
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private Plants planta;
    [SerializeField] private bool isAttacking = false;
    float timer = 0;

    private void Awake() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (life <= 0) Destroy(gameObject);
        if (isAttacking) {
            walkSpeed = 0;
            if (planta.GetHp() >= 0) {
                if (timer < attackSpeed) {
                    timer += Time.deltaTime;
                } else {
                    planta.DamagePlants(damage);
                    timer = 0;
                }
            } else planta.MataPlanta();
        } else walkSpeed = fixedSpeed;
    }

    private void FixedUpdate() {
        Vector2 position = rigidbody.position;
        Vector2 translation = Time.fixedDeltaTime * walkSpeed * Vector2.left;
        rigidbody.MovePosition(position + translation);
    }

    public void DamageEnemy(int damage) {
        life -= damage;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 9) {
            planta = other.gameObject.GetComponent<Plants>();
            isAttacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == 9) isAttacking = false;
    }
}
