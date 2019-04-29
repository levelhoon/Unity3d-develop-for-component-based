using System.Collections.Generic;
using UnityEngine;
class ActiveOff : EventComponent
{
    public override void Invoke()
    {
        ObjectPool.Get(tag).SetOff(transform);
    }
}
