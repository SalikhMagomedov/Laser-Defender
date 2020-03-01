using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        health -= damageDealer.Damage;
        damageDealer.Hit();
    }
}
