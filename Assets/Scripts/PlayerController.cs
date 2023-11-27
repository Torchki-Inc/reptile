using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using System.IO; 
using System.Text;
using System.Runtime.CompilerServices;

public class PlayerData{
    public int hp;
    public float moveSpeed;
    public List<Item> items;
    public float fireRate;
    public int balance;
    public int damage;
    public string race;
    
}

public class Item
{
    public string name{ get; set; }
    public int val{ get; set; }
    public Action effect{ get; set; }

    public Item(string Name, int Val, Action Effect){
        name = Name;
        val = Val;
        effect = Effect;
    }
}

public class PlayerController : MonoBehaviour
{
    //public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    public Sprite[] sectorSprites; 
    private SpriteRenderer playerSpriteRenderer;
    private float time;

    Vector2 moveDirection;
    Vector2 mousePosition;

    public PlayerData player;

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        using(StreamReader reader = new StreamReader("Assets/DataSheets/LizardPlayerDataX.txt")){
            player.hp = Int32.Parse(reader.ReadLine());
            player.moveSpeed = Int32.Parse(reader.ReadLine());
            player.fireRate = float.Parse(reader.ReadLine());
            player.balance = Int32.Parse(reader.ReadLine());
            player.damage = Int32.Parse(reader.ReadLine());
            player.race = reader.ReadLine();

        }
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((time += Time.deltaTime) > player.fireRate)
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
