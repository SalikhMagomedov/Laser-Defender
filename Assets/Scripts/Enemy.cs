using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float health = 100;
    [SerializeField] private int scoreValue = 150;

    [Header("Shooting")]
    [SerializeField] private float minTimeBetweenShots = 0.2f;
    [SerializeField] private float maxTimeBetweenShots = 3f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = 10f;

    [Header("FX")]
    [SerializeField] private GameObject particleExplosion;
    [SerializeField] private float durationOfExplosion = 1f;
    [SerializeField] private AudioClip deathSfx;
    [SerializeField] [Range(0, 1)] private float deathSfxVolume = .75f;
    [SerializeField] private AudioClip shootSfx;
    [SerializeField] [Range(0, 1)] private float shootSfxVolume = .25f;

    private float shotCounter;

    private void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
        }
    }

    private void Fire()
    {
        var laser = Instantiate(projectile, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);

        AudioSource.PlayClipAtPoint(shootSfx, Camera.main.transform.position, shootSfxVolume);

        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.Damage;
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var explosion = Instantiate(particleExplosion, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSfx, Camera.main.transform.position, deathSfxVolume);
        FindObjectOfType<GameSession>().AddtoScore(scoreValue);
        Destroy(gameObject);
    }
}
