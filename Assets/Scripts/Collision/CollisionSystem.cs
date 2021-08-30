using System.Collections.Generic;
using Entitas;

public class CollisionSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public CollisionSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collision);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var first = entity.collision.first;
            var second = entity.collision.second;

            var firstEntity = _contexts.game.GetEntitiesWithView(first).SingleEntity();
            var secondEntity = _contexts.game.GetEntitiesWithView(second).SingleEntity();

            CreateHitEffect(firstEntity);

            firstEntity.isDestroy = true;
            if(!secondEntity.hasTakingDamage) secondEntity.AddTakingDamage(firstEntity.damage.value);
        }
    }

    private void CreateHitEffect(GameEntity entity)
    {
        var hitEffect = _contexts.game.CreateEntity();
        hitEffect.AddAge(0);
        hitEffect.AddMaxAge(entity.deathEffect.age);
        hitEffect.AddResource(entity.deathEffect.view);
        hitEffect.AddInitialPosition(entity.view.value.transform.position);
    }
}
