using UnityEngine;

class Spawner : EventComponent
{
    [SerializeField]
    private Transform target = default;
    [SerializeField]
    private int size = default;
    protected static ObjectPool pool;

    public override void Invoke()
    {
        pool.SetOn();
    }
    private void Awake()
    {
        pool = ObjectPool.CreatePool(target, size);
    }
}
