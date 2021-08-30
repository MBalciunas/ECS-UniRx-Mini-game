using UnityEngine;

[CreateAssetMenu]
public class Gun : ScriptableObject
{
    public GameObject projectile;
    public GameObject projectileHitEffect;
    public int damage;
    public float attackCooldown;
    public float projectileSpeed;

}
