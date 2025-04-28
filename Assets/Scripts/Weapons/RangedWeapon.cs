using UnityEngine;

public class RangedWeapon : Weapon
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireRate = 0.5f;

    private float lastFireTime;

    public override void Attack()
    {
        if (Time.time >= lastFireTime + fireRate)
        {
            lastFireTime = Time.time;
            Shoot();
        }
    }

    private void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning("Bullet prefab or firePoint not assigned!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = firePoint.right * bulletSpeed; // Assuming firePoint right is forward
        }

        Debug.Log($"{weaponName} fired a bullet!");
    }
}