using Entitas;
using UniRx;
using UnityEngine;

public class InitializePlayerSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.isPlayer = true;
        var player = _contexts.game.gameSetup.value.player;
        entity.AddResource(player.prefab);
        entity.AddInitialPosition(new Vector3(0, 0, 0));
        entity.AddInitialRotation(Quaternion.Euler(0, 0, 0));
        entity.AddVelocity(Vector3.zero);
        entity.AddGun(player.gun.projectile, player.gun.projectileHitEffect, player.gun.projectileSpeed, player.gun.damage);
        entity.AddHealth(new ReactiveProperty<int>(player.health));
        entity.AddCooldown(0.2f, 0f);
        entity.AddRotation(Quaternion.identity);
    }
}