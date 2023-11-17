using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    public Sprite[] sectorSprites; 
    private SpriteRenderer playerSpriteRenderer;

    private float time;

    
    Vector2 moveDirection;
    Vector2 mousePosition;

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((time += Time.deltaTime) > weapon.fireRate)
        {
            if (Input.GetMouseButton(0))
            {
                time = 0.0f;
                weapon.Fire();
            }   
        }

        

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        int sector = Mathf.FloorToInt((angle + 22.5f) / 45f) % 8;
        sector = (sector + 8) % 8;
        playerSpriteRenderer.sprite = sectorSprites[sector];
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
