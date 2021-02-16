using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : PlayerState
{
    private Player _player;
    private Vector3 _movePoint;
    public MoveState(Player player, Vector3 movePoint)
    {
        _player = player;
        _movePoint = movePoint;
        _player.MoveToPoint(_movePoint);
        _player.RotateToPoint(_movePoint);
    }
    
    public void Execute()
    {
        if (InputManager.actionButtonDown)
        {
            UpdateMoveState();
        }
        _player.speed = _player.settings.moveSpeed;
        float velocity = Vector3.Magnitude(_player.velocity);
        _player.animator.SetFloat("Velocity", velocity);
    }

    private void UpdateMoveState()
    {
        Vector3 hitPosition = RaycastUtility.GetRaycastMousePosition();
        if (hitPosition != Vector3.zero)
            _player.SetState(new MoveState(_player, hitPosition));
    }
}