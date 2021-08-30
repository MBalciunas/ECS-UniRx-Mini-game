using Entitas;
using UnityEngine;

[Game]
public class GunComponent : IComponent
{
    public GameObject projectileView;
    public GameObject hitEffect;
    public float projectileSpeed;
    public int damage;
}