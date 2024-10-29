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
    public AudioSource audioSource;
    public AudioClip impactSound; // Ljudklipp f�r kollision
    [SerializeField] private float impactVolume = 1.5f; // Volymen f�r ljudet, justerbar fr�n Inspector

    private void Awake()
    {
        direction = Vector3.up;
        Shake = FindAnyObjectByType<ScreenShake>();
    }

    private void Start()
    {
        // Initiera ljudk�llan om det beh�vs
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
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

            var healthComponent = collision.GetComponent<BossControll>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamageBoss(1);
            }
        }
    }

    void CheckCollision(Collider2D collision)
    {
        Bunker bunker = collision.gameObject.GetComponent<Bunker>();
        Missile missile = collision.gameObject.GetComponent<Missile>();

        if (missile == null) // Om det inte �r en bunker vi tr�ffat s� ska skottet f�rsvinna.
        {
            SpawnDamageParticles(); // Spawna in partiklar
            Shake.startshake();

            // Spela upp ljudet oberoende av objektet med justerbar volym
            AudioSource.PlayClipAtPoint(impactSound, transform.position, impactVolume);

            Destroy(gameObject);
        }

        if (collision.tag == "Missile")
        {
            Destroy(collision.gameObject);
        }
    }

    private void SpawnDamageParticles()
    {
        damageParticalsInstance = Instantiate(damageParticals, transform.position, Quaternion.identity);
    }
}
