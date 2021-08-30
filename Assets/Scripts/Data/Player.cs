using UnityEngine;

[CreateAssetMenu]
public class Player : ScriptableObject
{
    public GameObject prefab;
    public Gun gun;
    public int health;
    public float moveSpeed;
}
