using System.Collections;
using UnityEngine;

class CollisionToTarget : ToTarget
{
    [SerializeField]
    private OnCollision onCollision = default;

    public override void Invoke()
    {
        if (To.gameObject.activeSelf)
        {
            return;
        }
        To = onCollision.Target as Transform;        
    }

    private void FixedUpdate()
    {
        base.Invoke();
    }
}

