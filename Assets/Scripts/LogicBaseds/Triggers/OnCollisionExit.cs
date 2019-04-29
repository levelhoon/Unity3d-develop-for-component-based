using UnityEngine;

class OnCollisionExit : OnCollision
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        Target = collision.transform;
        InvokeAll();
    }
}
