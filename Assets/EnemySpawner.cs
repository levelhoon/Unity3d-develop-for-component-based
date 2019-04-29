using UnityEngine;

class EnemySpawner : Spawner
{
    [SerializeField]
    float distanceMax = 40f;

    public override void Invoke()
    {
        base.Invoke();

        float angle = Random.Range(0.0f, 360.0f);
        float distance = Random.Range(0f, distanceMax);
        pool.Current.position = Mathv.GetVector2(angle, distance);
    }
}