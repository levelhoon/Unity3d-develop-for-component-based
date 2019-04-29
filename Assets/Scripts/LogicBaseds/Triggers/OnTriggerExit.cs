using UnityEngine;

class OnTriggerExit : OnCollision
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        Target = collision.transform;
        InvokeAll();
    }
}
