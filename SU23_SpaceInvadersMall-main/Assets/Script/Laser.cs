using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Laser : Projectile
{
    [SerializeField] private ParticleSystem damageParticals;
    private ParticleSystem damageParticalsInstance;
    private void Awake()
    {
        direction = Vector3.up;
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

        if(bunker == null) //Om det inte är en bunker vi träffat så ska skottet försvinna.
        {
            
            SpawnDamgeParticals(); //Spawna in particlar 
            
            Destroy(gameObject);

          

        }


    }
    private void SpawnDamgeParticals()
    {
        damageParticalsInstance = Instantiate(damageParticals, transform.position, Quaternion.identity);
    }
}
