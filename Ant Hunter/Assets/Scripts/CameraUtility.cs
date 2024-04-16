using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraExtensions
{
    public static Vector2 GetExtents(this Camera camera)
    {
        var orthographicSize = camera.orthographicSize;
        return new Vector2(orthographicSize * Screen.width/Screen.height, orthographicSize);
    }

    public static float GetRadiusAroundCamera(this Camera camera)
    {
        var doubleExtents = GetExtents(camera);
        return Mathf.Sqrt(doubleExtents.x * doubleExtents.x + doubleExtents.y * doubleExtents.y);
    }
}
