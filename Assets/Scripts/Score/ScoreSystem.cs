using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ScoreSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public ScoreSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroy);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroy && entity.isEnemy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            _contexts.game.score.value.SetValueAndForceNotify(_contexts.game.score.value.Value + 1);
        }
    }
}
