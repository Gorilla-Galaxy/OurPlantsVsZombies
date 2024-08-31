using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected Plants father;
    [SerializeField] protected int damage;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected new Rigidbody2D rigidbody;
    [SerializeField] protected Vector3 direction;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        damage = father.GetDamage();
        direction = Vector2.right;
    }

    private void FixedUpdate() {
        MoveBullet();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            other.GetComponent<Zombies>().DamageEnemy(damage);
            Destroy(gameObject);
        }
    }

    public void MoveBullet() {
        Vector2 position = rigidbody.position;
        Vector2 translation = bulletSpeed * Time.fixedDeltaTime * direction;
        rigidbody.MovePosition(position + translation);
        if (transform.position.x >= 10) {
            Destroy(gameObject);
        }
    }
}
