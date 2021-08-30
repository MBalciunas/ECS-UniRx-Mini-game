using Entitas;
using UnityEngine;

[Game]
public class MoveSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;

    public MoveSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Velocity, GameMatcher.View));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            var view = entity.view.value;
            var velocity = entity.velocity.velocity;
            var position = view.transform.position;
            position += velocity * _contexts.game.time.deltaTime;
            
            if (IsPlayerOutOfBounds(position, entity)) continue;
                
            view.transform.position = position;
        }
    }

    private static bool IsPlayerOutOfBounds(Vector3 position, GameEntity entity)
    {
        return entity.isPlayer && (position.x > 17 || position.x < -17 || position.y > 10 || position.y < -8);
    }
}