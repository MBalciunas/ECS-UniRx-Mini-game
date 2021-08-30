using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class DestroySystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public DestroySystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroy);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.hasDeathEffect)
            {
                var destroyEffect = _contexts.game.CreateEntity();
                destroyEffect.AddResource(entity.deathEffect.view);
                destroyEffect.AddInitialPosition(entity.view.value.transform.position);
                destroyEffect.AddMaxAge(entity.deathEffect.age);
                destroyEffect.AddAge(0);
            }
            if (entity.hasView)
            {
                var view = entity.view.value;
                if(view.GetEntityLink().entity != null) view.Unlink();
                Object.Destroy(view);
            }
            
            entity.Destroy();
        }
    }
}
