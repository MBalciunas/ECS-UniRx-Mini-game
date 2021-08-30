using Entitas;
using UnityEngine;
using static GameMatcher;

public class EnemyRotateSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;

    public EnemyRotateSystem(Contexts context) 
    {
        _contexts = context;
        _group = context.game.GetGroup(AllOf(EnemyRotate));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            var entityTransform = entity.view.value.transform;
            var diff = entity.target.transform.position - entityTransform.position;
            var f = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            entity.ReplaceRotation(Quaternion.Euler(0, 0, f - 90));
        }
    }
}
