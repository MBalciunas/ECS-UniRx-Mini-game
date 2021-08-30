using Entitas;
using UniRx;
using UnityEngine;

public class EnemySpawnSystem : IExecuteSystem
{
    private Contexts _contexts;
    private EnemiesData _enemiesData;

    public EnemySpawnSystem(Contexts contexts)
    {
        _contexts = contexts;
        _enemiesData = contexts.game.gameSetup.value.enemiesData;
        _contexts.game.SetEnemySpawn(0f);
    }

    public void Execute()
    {
        if (_contexts.game.enemySpawn.lastTimeSpawn + _enemiesData.spawnRate < _contexts.game.time.time)
        {
            _contexts.game.ReplaceEnemySpawn(_contexts.game.time.time);

            SpawnEnemyEntity();
        }
    }

    private void SpawnEnemyEntity()
    {
        var entity = _contexts.game.CreateEntity();
        var enemies = _enemiesData.Enemies;
        var enemyToSpawn = enemies[Random.Range(0, enemies.Length)];
        entity.AddResource(enemyToSpawn.view);
        entity.AddVelocity(Vector3.zero);
        entity.AddInitialPosition(new Vector3(Random.Range(-15, 15), Random.Range(-7, 7), 0f));
        entity.AddInitialRotation(Quaternion.Euler(0, 0, 0));
        entity.AddTarget(_contexts.game.playerEntity.view.value.transform);
        entity.AddCooldown(enemyToSpawn.gun.attackCooldown, 0f);
        entity.AddGun(enemyToSpawn.gun.projectile, enemyToSpawn.gun.projectileHitEffect, enemyToSpawn.gun.projectileSpeed, enemyToSpawn.gun.damage);
        entity.AddMoveSpeed(enemyToSpawn.moveSpeed);
        entity.AddHealth(new ReactiveProperty<int>(enemyToSpawn.health));
        entity.AddAttackRange(enemyToSpawn.attackRange);
        entity.AddDeathEffect(enemyToSpawn.deathEffect, enemyToSpawn.deathEffectTime);
        entity.isEnemyRotate = true;
        entity.isEnemy = true;
    }
}
