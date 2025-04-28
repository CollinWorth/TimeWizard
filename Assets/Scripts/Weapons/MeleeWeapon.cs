using UnityEngine;

public class MeleeWeapon : Weapon
{
    public float attackRange = 1.5f;
    public float attackCooldown = 1f;

    private float lastAttackTime;

    public override void Attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            Debug.Log($"{weaponName} performs melee attack for {damage} damage!");
            // TODO: Add melee hit detection logic here (e.g., raycast or overlap circle)
        }
    }
}