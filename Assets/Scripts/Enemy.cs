using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    private float stoppingDistance = 2f;
    public EnemyWeapon weapon;
    private float time;

    void Update()
    {
        GameObject player = GameObject.Find("Player");

        float distance = Vector2.Distance(player.transform.position, transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (distance > stoppingDistance)
        {
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
        }
        else if (distance < stoppingDistance)
        {
            transform.Translate(-direction.normalized * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.zero);
        }

        if ((time += Time.deltaTime) > weapon.fireRate)
        {
            time = 0.0f;
            weapon.Fire();
        }
    }
}