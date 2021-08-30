using Entitas;
using UnityEngine;
using static GameMatcher;

public class EnemyStateSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;

    public EnemyStateSystem(Contexts context)
    {
        _contexts = context;
        _group = context.game.GetGroup(AllOf(GameMatcher.Enemy));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            var entityTransform = entity.view.value.transform;

            if (Vector2.Distance(entityTransform.position, entity.target.transform.position) > entity.attackRange.value)
            {
                entity.isEnemyMove = true;
                entity.isShooting = false;
            }
            else if (entity.isFireable)
            {
                entity.isEnemyMove = false;
                entity.isShooting = true;
            }
            else
            {
                entity.isEnemyMove = false;
                entity.isShooting = false;
            }
        }
    }
}