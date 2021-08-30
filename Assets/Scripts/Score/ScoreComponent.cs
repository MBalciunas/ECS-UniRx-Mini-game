using Entitas;
using Entitas.CodeGeneration.Attributes;
using UniRx;

[Game, Unique]
public class ScoreComponent : IComponent
{
    public ReactiveProperty<int> value;
}
