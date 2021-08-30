using Entitas;

public class MaxAgeSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;
    
    public MaxAgeSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Age, GameMatcher.MaxAge));
    }
    
    public void Execute()
    {
        foreach (var entity in _group)
        {
            if (entity.age.value >= entity.maxAge.value)
            {
                entity.isDestroy = true;
            }
        }
    }
}