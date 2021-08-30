using Entitas;

public class AgingSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;

    public AgingSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.Age);
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            entity.ReplaceAge(entity.age.value + _contexts.game.time.deltaTime);    
        }
    }
}
