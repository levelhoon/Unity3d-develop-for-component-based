using UnityEngine;

static class Mathv
{
    public static Vector2 GetVector2(float degree, float scalar)
    {
        float x, y, radian;
        radian = degree * Mathf.Deg2Rad;
        x = Mathf.Cos(radian);
        y = Mathf.Sin(radian);
        return new Vector2(x, y) * scalar;
    }

    public static Vector2 GetVector2(ref this Vector2 v, float degree, float scalar)
    {
        return v = GetVector2(degree, scalar);
    }
}