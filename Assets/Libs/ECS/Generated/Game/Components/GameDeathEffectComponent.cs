//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DeathEffectComponent deathEffect { get { return (DeathEffectComponent)GetComponent(GameComponentsLookup.DeathEffect); } }
    public bool hasDeathEffect { get { return HasComponent(GameComponentsLookup.DeathEffect); } }

    public void AddDeathEffect(UnityEngine.GameObject newView, float newAge) {
        var index = GameComponentsLookup.DeathEffect;
        var component = (DeathEffectComponent)CreateComponent(index, typeof(DeathEffectComponent));
        component.view = newView;
        component.age = newAge;
        AddComponent(index, component);
    }

    public void ReplaceDeathEffect(UnityEngine.GameObject newView, float newAge) {
        var index = GameComponentsLookup.DeathEffect;
        var component = (DeathEffectComponent)CreateComponent(index, typeof(DeathEffectComponent));
        component.view = newView;
        component.age = newAge;
        ReplaceComponent(index, component);
    }

    public void RemoveDeathEffect() {
        RemoveComponent(GameComponentsLookup.DeathEffect);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDeathEffect;

    public static Entitas.IMatcher<GameEntity> DeathEffect {
        get {
            if (_matcherDeathEffect == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DeathEffect);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDeathEffect = matcher;
            }

            return _matcherDeathEffect;
        }
    }
}
