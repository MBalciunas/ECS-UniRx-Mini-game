//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MaxAgeComponent maxAge { get { return (MaxAgeComponent)GetComponent(GameComponentsLookup.MaxAge); } }
    public bool hasMaxAge { get { return HasComponent(GameComponentsLookup.MaxAge); } }

    public void AddMaxAge(float newValue) {
        var index = GameComponentsLookup.MaxAge;
        var component = (MaxAgeComponent)CreateComponent(index, typeof(MaxAgeComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMaxAge(float newValue) {
        var index = GameComponentsLookup.MaxAge;
        var component = (MaxAgeComponent)CreateComponent(index, typeof(MaxAgeComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMaxAge() {
        RemoveComponent(GameComponentsLookup.MaxAge);
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

    static Entitas.IMatcher<GameEntity> _matcherMaxAge;

    public static Entitas.IMatcher<GameEntity> MaxAge {
        get {
            if (_matcherMaxAge == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MaxAge);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMaxAge = matcher;
            }

            return _matcherMaxAge;
        }
    }
}
