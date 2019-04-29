using UnityEngine;

class Move : Motion
{
    public override void Invoke()
    {
        transform.position += Velocity * Time.smoothDeltaTime;
    }
}
