using System.Collections;
using UnityEngine;

class RangedAttack : Attack
{
    [SerializeField]
    private Transform ball = default;
    [SerializeField]
    private Transform[] launcher = new Transform[0];
    public static ObjectPool pool;

    public override void Invoke()
    {
        for (int i = 0; i < launcher.Length; i++)
        {
            pool.SetOn();
            pool.Current.position = launcher[i].position;
            //ObjectPool.GetComponents<Move>(pool.Current)[0].Direction = launcher[i].up.normalized;
        }
    }

    private void Awake()
    {
        pool = pool ?? ObjectPool.CreatePool(ball, 180);
        //ObjectPool.UploadComponents<Move>(ball);
    }
}
