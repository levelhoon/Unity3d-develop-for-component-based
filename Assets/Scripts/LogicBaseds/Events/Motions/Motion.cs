using UnityEngine;

abstract class Motion : EventComponent
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 direction;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    public Vector3 Direction
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value.normalized;
        }
    }
    public Vector3 Velocity
    {
        get
        {
            return direction * speed;
        }
    }
}
