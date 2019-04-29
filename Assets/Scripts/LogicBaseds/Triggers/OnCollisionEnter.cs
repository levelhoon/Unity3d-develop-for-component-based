using UnityEngine;


class OnCollisionEnter : OnCollision
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Target = collision.transform;
        InvokeAll();
    }
}
