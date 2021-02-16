using UnityEngine;

public class IdleState : PlayerState
{
    private Player _player;

    public IdleState(Player player)
    {
        _player = player;
    }

    public void Execute()
    {
        
        if (InputManager.actionButtonDown)
        {
            Vector3 hitPosition = RaycastUtility.GetRaycastMousePosition();

            if (hitPosition != Vector3.zero)
                _player.SetState(new MoveState(_player, hitPosition));
        }
    }
}