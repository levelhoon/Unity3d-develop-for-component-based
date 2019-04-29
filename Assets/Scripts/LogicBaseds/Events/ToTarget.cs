using UnityEngine;

class ToTarget : EventComponent
{
    [SerializeField]
    Motion motion = default;
    [SerializeField]
    Transform from = default;
    [SerializeField]
    Transform to = default;

    protected Motion Motion
    {
        get
        {
            return motion;
        }
        set
        {
            motion = value;
        }
    }
    protected Transform From
    {
        get
        {
            return from;
        }
        set
        {
            from = value;
        }
    }
    protected Transform To
    {
        get
        {
            return to;
        }
        set
        {
            to = value;
        }
    }

    public override void Invoke()
    {
        motion.Direction = (to.position - from.position).normalized;
    }
}

