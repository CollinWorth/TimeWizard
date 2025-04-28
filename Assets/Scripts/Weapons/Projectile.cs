using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    public float lifeTime = 3f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Example: deal damage if target has health component
        //var health = collision.GetComponent<Health>();
        //if (health != null)
        //{
        //    health.TakeDamage(damage);
        //}

        Destroy(gameObject); // Destroy bullet on impact
    }
}