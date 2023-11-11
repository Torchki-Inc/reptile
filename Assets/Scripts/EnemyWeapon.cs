using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] public float lifetime = 10f;
    [SerializeField] public float fireRate = 0.5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    public void Fire()
    {
        GameObject player = GameObject.FindWithTag("Player");

        Vector2 playerPosition = player.transform.position;

        Vector2 shootDirection = (playerPosition - (Vector2)firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection * fireForce, ForceMode2D.Impulse);

        Destroy(bullet, lifetime);
    }
}