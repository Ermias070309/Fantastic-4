using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControll : MonoBehaviour
{

    [SerializeField] Missile missilePrefab;
    public int maxHealthBoss = 10;
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

        if (currentHealthBoss <= 0)
        {
            SpawnDamgeParticals();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FireMissile()
    {
        for (int i = 0; i<30; i++)
        {
            float y = transform.position.y;
            float x = transform.position.x - 15 + i;
            Instantiate(missilePrefab, new Vector3(x, y), Quaternion.identity); 

        }
    }
    private void SpawnDamgeParticals()
    {
        damageParticalsInstance = Instantiate(damageParticals, transform.position, Quaternion.identity);
    }
}
