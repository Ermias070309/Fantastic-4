using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossControll : MonoBehaviour
{

    [SerializeField] Missile missilePrefab;
    public int maxHealthBoss = 6;
    public int currentHealthBoss;
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
        if (currentHealthBoss <= 5)
        {
            
        }
        if (currentHealthBoss <= 0)
        {
            SpawnDamgeParticals();
            Destroy(gameObject);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
            if(transform.position.x >= 15)
            {
                transform.Translate(Vector3.left * Time.deltaTime); 
            }
            if (transform.position.x <= -15)
            {
                transform.Translate(Vector3.right * Time.deltaTime);
            }
    }
    

    private void FireMissile()
    {
        int MissFire = Random.Range(0, 30);
        for (int i = 0; i<30; i++)
        {
            if(i < MissFire - 2 || i > MissFire + 2)
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
