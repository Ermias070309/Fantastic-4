using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public Laser laserPrefab;
    Laser laser;
    float speed = 20f;
    public int maxHealth = 4;
    public int currentHealth;
    float wait = 0;
    SpriteRenderer PG;
    public Sprite Player1;
    public Sprite Player2;
    public Sprite Player3;
   

    private void Start()
    {
        currentHealth = maxHealth;
        PG = GetComponent<SpriteRenderer>();
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void GetHealth(int amount)
    {
        currentHealth = amount;

        if (currentHealth > 0)
        {
            Destroy(gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += speed * Time.deltaTime;
        }
        if (currentHealth == 4)
        {
            PG.sprite = Player1;
        }
        if (currentHealth == 3)
        {
            PG.sprite = Player2;
        }
        if (currentHealth == 2)
        {
            PG.sprite = Player3;
        }
        

            transform.position = position;

        if (Input.GetKeyDown(KeyCode.Space) && Time.time - wait >= 1.5)
        {
            laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            wait = Time.time; 
        }
    }

    
}
