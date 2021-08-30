using Entitas;

[Game]
public class CooldownComponent : IComponent
{
    public float cooldown;
    public float lastTimeTriggered;
}
