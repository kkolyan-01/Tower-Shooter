using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RaycastUtility
{
    public static Ray GetMouseRay()
    {
        Vector3 screenMousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenMousePosition);
        return ray;
    }

    public static Vector3 GetRaycastPosition(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 point = hit.point;
            return point;
        }
        
        return Vector3.zero;
    }

    public static Vector3 GetRaycastMousePosition()
    {
        Ray mouseRay = GetMouseRay(); 
        return GetRaycastPosition(mouseRay);
    }
}
