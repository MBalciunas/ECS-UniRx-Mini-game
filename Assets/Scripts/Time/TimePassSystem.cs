using Entitas;
using UnityEngine;

public class TimePassSystem : IExecuteSystem
{
    private Contexts _contexts;

    public TimePassSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        _contexts.game.ReplaceTime(Time.time, Time.deltaTime);
    }
}
