using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine.SceneManagement;

public class GameOverSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public GameOverSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroy);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPlayer;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in _contexts.game.GetGroup(GameMatcher.View))
        {
            if (entity.view.value.GetEntityLink().entity != null)
                entity.view.value.Unlink();
        }
        
        SceneManager.LoadScene("GameOver");
    }
}