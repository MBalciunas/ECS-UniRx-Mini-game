using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using Object = UnityEngine.Object;

public class InstantiateViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public InstantiateViewSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Resource);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasResource;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var gameObject = Object.Instantiate(entity.resource.prefab);
            entity.AddView(gameObject);
            gameObject.Link(entity);

            if (entity.hasInitialPosition)
            {
                gameObject.transform.position = entity.initialPosition.position;
            }
            if (entity.hasInitialRotation)
            {
                gameObject.transform.rotation = entity.initialRotation.rotation;
            }
        }
    }
}
