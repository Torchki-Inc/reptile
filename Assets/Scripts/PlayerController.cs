using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using System.IO; 
using System.Text;

public class PlayerData{
    public int hp;
    public float moveSpeed;
    public Items items;
    public float fireRate;
    public int balance;
    public int damage;
}

public class Items
{
    public List<string> positive;
    public List<string> negative;
}

public class PlayerController : MonoBehaviour
{
    //public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    public Sprite[] sectorSprites; 
    private SpriteRenderer playerSpriteRenderer;
    private float time;
    
    static string jsonData = "{\"hp\":4,\"items\":{\"positive\":[],\"negative\":[]},\"moveSpeed\":5,\"fireRate\":10,\"balance\":0,\"damage\":1}";

    public PlayerData player = JsonUtility.FromJson<PlayerData>(jsonData);
    Vector2 moveDirection;
    Vector2 mousePosition;

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

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
        rb.velocity = new Vector2(moveDirection.x * player.moveSpeed, moveDirection.y * player.moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Bullet"){
            player.hp-=1;
        }
    }
}
