using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public GameObject view;
    public Gun gun;
    public GameObject deathEffect;
    public float attackRange;
    public float moveSpeed;
    public int health;
    public float deathEffectTime;
}
