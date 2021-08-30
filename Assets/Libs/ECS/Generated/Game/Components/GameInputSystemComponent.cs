//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public InputSystemComponent inputSystem { get { return (InputSystemComponent)GetComponent(GameComponentsLookup.InputSystem); } }
    public bool hasInputSystem { get { return HasComponent(GameComponentsLookup.InputSystem); } }

    public void AddInputSystem(InputSystem newValue) {
        var index = GameComponentsLookup.InputSystem;
        var component = (InputSystemComponent)CreateComponent(index, typeof(InputSystemComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInputSystem(InputSystem newValue) {
        var index = GameComponentsLookup.InputSystem;
        var component = (InputSystemComponent)CreateComponent(index, typeof(InputSystemComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInputSystem() {
        RemoveComponent(GameComponentsLookup.InputSystem);
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

    static Entitas.IMatcher<GameEntity> _matcherInputSystem;

    public static Entitas.IMatcher<GameEntity> InputSystem {
        get {
            if (_matcherInputSystem == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InputSystem);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInputSystem = matcher;
            }

            return _matcherInputSystem;
        }
    }
}
