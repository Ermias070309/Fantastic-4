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
    // Start is called before the first frame update
    void Start()
    {
        currentHealthBoss = maxHealthBoss;
        InvokeRepeating(nameof(FireMissile), 1f, 2.6f); 
    }

    public void TakeDamageBoss(int amount)
    {
        currentHealthBoss -= amount;
        
        if (currentHealthBoss <= 0)
        {
            SpawnDamgeParticals();
            Destroy(gameObject);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if(currentHealthBoss <= 5)
        {
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
