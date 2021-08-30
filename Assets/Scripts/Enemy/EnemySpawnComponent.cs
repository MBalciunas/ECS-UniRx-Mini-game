using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class EnemySpawnComponent : IComponent
{
    public float lastTimeSpawn;
}
