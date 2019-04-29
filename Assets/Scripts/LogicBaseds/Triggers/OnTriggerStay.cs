using UnityEngine;

class OnTriggerStay : OnCollision
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Target = collision.transform;
        InvokeAll();
    }
}
