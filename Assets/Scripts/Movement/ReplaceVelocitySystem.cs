using Entitas;
using static GameMatcher;

[Game]
public class ReplaceVelocitySystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;
    
    public ReplaceVelocitySystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(AllOf(Velocity, View));
    }
    public void Execute()
    {
        var input = _contexts.game.input.value;
        var player = _contexts.game.playerEntity;
        var movementSpeed = _contexts.game.gameSetup.value.player.moveSpeed;
        player.ReplaceVelocity(input * movementSpeed);
    }
}
