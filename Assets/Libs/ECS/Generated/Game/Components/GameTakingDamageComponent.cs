//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TakingDamageComponent takingDamage { get { return (TakingDamageComponent)GetComponent(GameComponentsLookup.TakingDamage); } }
    public bool hasTakingDamage { get { return HasComponent(GameComponentsLookup.TakingDamage); } }

    public void AddTakingDamage(int newDamage) {
        var index = GameComponentsLookup.TakingDamage;
        var component = (TakingDamageComponent)CreateComponent(index, typeof(TakingDamageComponent));
        component.damage = newDamage;
        AddComponent(index, component);
    }

    public void ReplaceTakingDamage(int newDamage) {
        var index = GameComponentsLookup.TakingDamage;
        var component = (TakingDamageComponent)CreateComponent(index, typeof(TakingDamageComponent));
        component.damage = newDamage;
        ReplaceComponent(index, component);
    }

    public void RemoveTakingDamage() {
        RemoveComponent(GameComponentsLookup.TakingDamage);
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

    static Entitas.IMatcher<GameEntity> _matcherTakingDamage;

    public static Entitas.IMatcher<GameEntity> TakingDamage {
        get {
            if (_matcherTakingDamage == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TakingDamage);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTakingDamage = matcher;
            }

            return _matcherTakingDamage;
        }
    }
}