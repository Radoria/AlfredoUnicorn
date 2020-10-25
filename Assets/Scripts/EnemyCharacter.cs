using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    public float shootTimer;
    public float shootCooldown;
    public float shotSpeed;

    public GameObject bullet;
    public Transform positionLeft;
    public Transform positionRight;

    public SpriteRenderer spriteRenderer;

    public bool ShotTimer;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 2f;
        ShotTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateShootingCooldown(shootCooldown);
        Shoot();
    }

    void CalculateShootingCooldown(float cooldown)
    {
        if (ShotTimer)
            shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            ShotTimer = false;
            shootTimer = cooldown;
        }
    }

    protected virtual void Shoot()
    {
        if (!ShotTimer)
        {
            if (!spriteRenderer.flipX)
            {
                GameObject newBullet = Instantiate(bullet, positionLeft.position, transform.rotation);
                newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * -shotSpeed;
            }
            else
            {
                GameObject newBullet = Instantiate(bullet, positionRight.position, transform.rotation);
                newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * shotSpeed;
            }
            ShotTimer = true;
        }
    }
}
