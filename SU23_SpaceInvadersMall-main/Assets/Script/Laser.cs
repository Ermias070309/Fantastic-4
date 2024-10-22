using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Laser : Projectile
{
    ScreenShake Shake;

    [SerializeField] private ParticleSystem damageParticals;
    private ParticleSystem damageParticalsInstance;
    private void Awake()
    {
        direction = Vector3.up;
        Shake = FindAnyObjectByType<ScreenShake>(); 
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision);

        if (collision.CompareTag("Bunker"))
        {
            Destroy(gameObject);
        }
        if (collision.tag == "MysteryShip")
        {
            Destroy(gameObject);

            var healthComponnent = collision.GetComponent<BossControll>();
            if (healthComponnent != null)
            {
                healthComponnent.TakeDamageBoss(1);
            }
        }
    }

    void CheckCollision(Collider2D collision)
    {
        Bunker bunker = collision.gameObject.GetComponent<Bunker>();
        Missile missile = collision.gameObject.GetComponent<Missile>();

        if ( missile == null) //Om det inte är en bunker vi träffat så ska skottet försvinna.
        {
            
            SpawnDamgeParticals(); //Spawna in particlar 
            Shake.startshake();
            
            Destroy(gameObject);
            Thread.Sleep(80); 

          

        }
        if (collision.tag == "Missile")
        {
            Destroy(collision.gameObject);
        }

    }
    private void SpawnDamgeParticals()
    {
        damageParticalsInstance = Instantiate(damageParticals, transform.position, Quaternion.identity);
    }
}
