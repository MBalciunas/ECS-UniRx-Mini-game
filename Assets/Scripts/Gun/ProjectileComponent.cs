using Entitas;
using UnityEngine;

[Game]
public class ProjectileComponent : IComponent
{
    public GameObject view;
    public int damage;
    public float speed;
}
