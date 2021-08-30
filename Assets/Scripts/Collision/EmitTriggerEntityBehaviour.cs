using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class EmitTriggerEntityBehaviour : MonoBehaviour
{
    private void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Subscribe(other =>
            {
                var entity = Contexts.sharedInstance.game.CreateEntity();
                entity.AddCollision(gameObject, other.gameObject);
            });
    }
}