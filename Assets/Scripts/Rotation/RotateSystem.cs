using Entitas;
using UnityEngine;
using static GameMatcher;

public class RotateSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;
    
    public RotateSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(AllOf(Rotation, View));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            var view = entity.view.value;
            view.transform.rotation = entity.rotation.value;
        }
    }
}
