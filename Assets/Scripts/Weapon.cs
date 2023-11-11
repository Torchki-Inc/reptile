using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{

    [SerializeField]public float lifetime = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    

    public void Fire()
    {
// Get the mouse position in world space
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the firePoint to the mouse position
        Vector2 shootDirection = (mousePosition - (Vector2)firePoint.position).normalized;

        // Instantiate the projectile at the firePoint position
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Get the projectile's rigidbody2D component
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Apply force to the projectile in the calculated direction
        rb.AddForce(shootDirection * 10f, ForceMode2D.Impulse);

        Destroy(bullet, lifetime);
    }
}
