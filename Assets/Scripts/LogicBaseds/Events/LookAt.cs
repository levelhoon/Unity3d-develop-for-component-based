using UnityEngine;

class LookAt : Motion
{
    public override void Invoke()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Direction);
    }
}

