using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
[CreateAssetMenu]
public class GameSetup : ScriptableObject
{
    public Player player;
    public EnemiesData enemiesData;
    
    public Camera mainCamera;

    private void OnEnable()
    {
        mainCamera = Camera.main;
    }
}
