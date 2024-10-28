using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossControll : MonoBehaviour
{

    [SerializeField] Missile missilePrefab;
    float speed = 10f; 
    public int maxHealthBoss = 6;
    public int currentHealthBoss;
    int direction = -1;
  [SerializeField] private ParticleSystem damageParticals;
    private ParticleSystem damageParticalsInstance;
    public Sprite boss1;
    public Sprite boss2;
    SpriteRenderer BS;

    // Start is called before the first frame update
    void Start()
    {
        BS = GetComponent<SpriteRenderer>();
        currentHealthBoss = maxHealthBoss;
        InvokeRepeating(nameof(FireMissile), 1f, 2.6f); 
    }

    public void TakeDamageBoss(int amount)
    {
        currentHealthBoss -= amount;
        if (currentHealthBoss == 3)
        {
            transform.position = new Vector3(0, 5, 0);
            BoxCollider2D BC = GetComponent<BoxCollider2D>();
            BC.size = new Vector2(3.628833f, 3.073158f);
            BC.offset = new Vector2(-0.1226101f, 3.453106f);
        }
        if (currentHealthBoss <= 0)
        {
            SpawnDamgeParticals();
            Destroy(gameObject);
            Debug.Log("Du van!! Tryck y för att spela igen eller n för att avsluta");
        }

    }

    
    // Update is called once per frame
    void Update()
    {
        if(currentHealthBoss <= 6 && currentHealthBoss !<= 3)
        {
            BS.sprite = boss1; 
        }
        if(currentHealthBoss <= 3)
        {
            transform.localScale = new Vector3(2, 2, 2);
            BS.sprite = boss2; 
            moveShip();
        }
        if (transform.position.x <= -15)
        {
            direction *= -1; //Ändrar riktningen
        }
        if (transform.position.x >= 15)
        {
            direction *= -1; //Ändrar riktningen
        }
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            currentHealthBoss = 0;
             
        }
        if (currentHealthBoss <= 0)
        {
            Destroy(gameObject); 
        }
    }

    private void moveShip()
    {
        if (direction == 1)
        {
            //rör sig åt höger
            transform.position += speed * Time.deltaTime * Vector3.right;
        }
        else
        {
            //rör sig åt vänster
            transform.position += speed * Time.deltaTime * Vector3.left;
        }
    }

    private void FireMissile()
    {
        int MissFire = Random.Range(0, 30);
        for (int i = 0; i<30; i++)
        {
            if(i < MissFire - 4 || i > MissFire + 4)
            {
                float y = 13;
                float x = - 15 + i;
                Instantiate(missilePrefab, new Vector3(x, y), Quaternion.identity);
            }
            
         
        }
    }
    private void SpawnDamgeParticals()
    {
        damageParticalsInstance = Instantiate(damageParticals, transform.position, Quaternion.identity);
    }
}
