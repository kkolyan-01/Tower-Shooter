using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static bool actionButtonPressed => Input.GetMouseButton(0) || Input.GetMouseButton(1);
    public static bool actionButtonDown => Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);
}
