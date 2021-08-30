using Entitas;
using UniRx;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameSetup gameSetup;
    private Systems _systems;
    private Contexts _contexts;
    private void Awake()
    {
        _contexts = Contexts.sharedInstance;

        _contexts.game.SetGameSetup(gameSetup);
        _contexts.game.SetScore(new ReactiveProperty<int>(0));
        _contexts.game.SetCamera(Camera.main);
                    
        _systems = CreateSystems(_contexts);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }

    void OnDestroy() {
        _systems.ClearReactiveSystems();
        _contexts.game.Reset();
    }
    
    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
                
            .Add(new InitializePlayerSystem(contexts))
            .Add(new InstantiateViewSystem(contexts))
            
            .Add(new TimePassSystem(contexts))
            .Add(new AgingSystem(contexts))
            .Add(new MaxAgeSystem(contexts))

            .Add(new InputSystem(contexts))
            .Add(new ReplaceVelocitySystem(contexts))
            .Add(new MoveSystem(contexts))
            .Add(new RotateSystem(contexts))

            .Add(new CollisionSystem(contexts))
            .Add(new AttackCooldownSystem(contexts))
            .Add(new ShootingSystem(contexts))
            .Add(new DamageSystem(contexts))
            
            .Add(new EnemyMoveSystem(contexts))
            .Add(new EnemyRotateSystem(contexts))
            .Add(new EnemyStateSystem(contexts))
            .Add(new EnemySpawnSystem(contexts))
            
            .Add(new ScoreSystem(contexts))
               
            .Add(new GameOverSystem(contexts))

            .Add(new DestroySystem(contexts));
    }
}
