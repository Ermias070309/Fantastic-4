using System.Collections;
using System.Collections.Generic;
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
    }

    void CheckCollision(Collider2D collision)
    {
        Bunker bunker = collision.gameObject.GetComponent<Bunker>();
        Missile missile = collision.gameObject.GetComponent<Missile>();

        if (bunker || missile == null) //Om det inte �r en bunker vi tr�ffat s� ska skottet f�rsvinna.
        {
            
            SpawnDamgeParticals(); //Spawna in particlar 
            Shake.startshake();
            
            Destroy(gameObject);

          

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
