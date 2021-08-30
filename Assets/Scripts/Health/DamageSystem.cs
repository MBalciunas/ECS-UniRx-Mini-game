using System.Collections.Generic;
using Entitas;

public class DamageSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public DamageSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.TakingDamage);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasTakingDamage && entity.hasHealth;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.health.value.Value - entity.takingDamage.damage <= 0)
            {
                entity.isDestroy = true;
            }
            else
            {
                entity.health.value.SetValueAndForceNotify(entity.health.value.Value - entity.takingDamage.damage);
            }
            entity.RemoveTakingDamage();
        }
    }
}
