using UnityEngine;

class OnCollisionStay : OnCollision
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        Target = collision.transform;
        InvokeAll();
    }
}