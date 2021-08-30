using Entitas;
using UnityEngine;

[Game]
public class InputSystem : IExecuteSystem
{
    private Contexts _contexts;

    public InputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var vertical = Input.GetAxisRaw("Vertical");
        var horizontal = Input.GetAxisRaw("Horizontal");
        
        var mouseScreenPos = Input.mousePosition;
        var player = _contexts.game.playerEntity;
        var startingScreenPos = _contexts.game.camera.camera.WorldToScreenPoint(player.view.value.transform.position);
        mouseScreenPos.x -= startingScreenPos.x;
        mouseScreenPos.y -= startingScreenPos.y;
        
        var angle = Mathf.Atan2(mouseScreenPos.y, mouseScreenPos.x) * Mathf.Rad2Deg;
        player.ReplaceRotation(Quaternion.Euler(0, 0, angle - 90));

        if (player.isFireable && Input.GetKeyDown(KeyCode.Mouse0))
        {
            player.isShooting = true;
        }

        _contexts.game.ReplaceInput(new Vector3(horizontal, vertical, 0f));
    }
}
