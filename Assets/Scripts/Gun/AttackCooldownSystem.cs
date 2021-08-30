using Entitas;
using UnityEngine;

public class AttackCooldownSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;

    public AttackCooldownSystem(Contexts contexts) 
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Cooldown, GameMatcher.Gun));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            if (entity.cooldown.lastTimeTriggered + entity.cooldown.cooldown < _contexts.game.time.time)
            {
                entity.isFireable = true;
            }
            else
            {
                entity.isShooting = false;
            }
        }
    }
}
