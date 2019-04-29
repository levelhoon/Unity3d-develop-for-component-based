using UnityEngine;

class OnTriggerEnter : OnCollision
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Target = collision.transform;
        InvokeAll();
    }
}
