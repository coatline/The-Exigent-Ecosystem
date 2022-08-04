using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Transform RotateTowardsDirection(this Transform tra, Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        tra.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        return tra;
    }
}
