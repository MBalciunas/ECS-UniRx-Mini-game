using Entitas;

public class ShootingSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;

    public ShootingSystem(Contexts context)
    {
        _contexts = context;
        _group = context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Shooting));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            var projectileEntity = _contexts.game.CreateEntity();
            projectileEntity.AddResource(entity.gun.projectileView);
            var entityTransform = entity.view.value.transform;
            var entityForward = entity.view.value.transform.up;
            projectileEntity.AddVelocity(entityForward * entity.gun.projectileSpeed);
            projectileEntity.AddInitialPosition(entityTransform.position);
            projectileEntity.AddInitialRotation(entityTransform.rotation);
            projectileEntity.AddDeathEffect(entity.gun.hitEffect, 0.3f);
            projectileEntity.AddAge(0);
            projectileEntity.AddMaxAge(4f);
            projectileEntity.AddDamage(entity.gun.damage);
            
            entity.isFireable = false;
            entity.cooldown.lastTimeTriggered = _contexts.game.time.time;
        }
    }
}