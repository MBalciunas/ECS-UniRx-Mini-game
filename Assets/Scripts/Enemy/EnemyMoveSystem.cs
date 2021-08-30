using Entitas;
using static GameMatcher;

public class EnemyMoveSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;

    public EnemyMoveSystem(Contexts context)
    {
        _contexts = context;
        _group = context.game.GetGroup(AllOf(EnemyMove));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            var entityTransform = entity.view.value.transform;
            entity.ReplaceVelocity(entity.moveSpeed.value * entityTransform.up);
        }
    }
}
