using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Plants father;
    [SerializeField] private int damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speedMod;

    private void Awake() { // ai aia iaia
        rigidbody = GetComponent<Rigidbody2D>();
        damage = father.GetDamage();
        SetDirection();
        speedMod = UnityEngine.Random.Range(0.02f, 0.04f);
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

    private void SetDirection() {
        if (father.gameObject.CompareTag("Sunflower")) {
            direction = Vector2.down;
        } else direction = Vector2.right;
    }

    private void MoveBullet() {
        Vector2 position = rigidbody.position;
        Vector2 translation = bulletSpeed * Time.fixedDeltaTime * direction;
        rigidbody.MovePosition(position + translation);
        if (father.gameObject.CompareTag("Sunflower")) {
            bulletSpeed -= 2 * speedMod;
            if (bulletSpeed < 0) {
                GetComponent<Bullet>().enabled = false;
            }
        }
        if (transform.position.x >= 10) {
            Destroy(gameObject);
        }
    }
}
