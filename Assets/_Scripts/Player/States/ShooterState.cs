using UnityEngine;

public class ShooterState : PlayerState
{
    private Player _player;
    private Weapon _weapon;

    public ShooterState(Player player, Weapon weapon)
    {
        _player = player;
        _weapon = weapon;
        _player.animator.SetBool("ShootPosition", true);
    }

    public void Execute()
    {
        Ray mouseRay = RaycastUtility.GetMouseRay(); 
        Vector3 point = RaycastUtility.GetRaycastPosition(mouseRay);
        _player.RotateToPoint(point);
        
        if (InputManager.actionButtonPressed)
        {
            if (_weapon.Shoot())
            {
                _player.animator.SetTrigger("Shoot");
            }
        }
    }
}