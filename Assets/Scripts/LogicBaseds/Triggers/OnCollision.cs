using System;
using UnityEngine;
using Component = UnityEngine.Component;

class OnCollision : TriggerComponent<IEvent<Component>>
{
    [SerializeField]
    private Event[] events = default;

    public Component Target { get; set; }

    protected override IEvent<Component>[] Events
    {
        get
        {
            return events;
        }
    }
    public override void InvokeAll()
    {
        for (int i = 0; i < events.Length; i++)
        {
            events[i].Handle = Target;
        }
        base.InvokeAll();
    }

    [Serializable]
    class Event : IEvent<Component>
    {
        [SerializeField]
        private string tagOfTarget = "Solid";
        [SerializeField]
        private EventComponent eventComponent = null;

        public Component Handle { get; set; }

        public void Invoke()
        {
            if (Handle == null)
            {
                return;
            }
            if (Handle.tag == tagOfTarget)
            {
                eventComponent.Invoke();
            }
        }
    }
}
