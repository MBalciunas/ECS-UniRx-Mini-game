using Entitas;
using UniRx;

[Game]
public class HealthComponent : IComponent
{
    public ReactiveProperty<int> value;
}
