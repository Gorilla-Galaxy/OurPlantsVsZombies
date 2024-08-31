using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSunflower : Bullet
{
    [SerializeField] private float speedMod;
    [SerializeField] private bool isSunDrop = false;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        direction = Vector2.down;
        speedMod = UnityEngine.Random.Range(0.02f, 0.04f);
    }

    void FixedUpdate()
    {
        MoveSun();
    }

    private void MoveSun() // Template Method Pattern - Instead of overriding MoveBullet, we use it and expand on
    {
        MoveBullet();
        if (!isSunDrop)
        {
            if (transform.position.y > 6)
            {
                SetSunState(true);
            }
            bulletSpeed -= 2 * speedMod;
            if (bulletSpeed < 0)
            {
                GetComponent<BulletSunflower>().enabled = false;
            }
        }
    }
    public void SetSunState(bool state)
    {
        isSunDrop = state;
    }
}
