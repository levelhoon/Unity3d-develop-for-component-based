using System;
using System.Collections.Generic;
using UnityEngine;

abstract class TriggerComponent<T> : MonoBehaviour where T : IEvent
{
    protected abstract T[] Events { get; }

    public virtual void InvokeAll()
    {
        for (int i = 0; i < Events.Length; i++)
        {
            var getEvent = Events[i];
            getEvent.Invoke();
        }
    }

    private void Awake()
    {
        if (Events.Length == 0)
        {
            Debug.LogError(this + "의 이벤트가 비어있습니다 확인바랍니다.");
        }
    }
}

abstract class TriggerComponent : TriggerComponent<EventComponent>
{
    [SerializeField]
    EventComponent[] events = new EventComponent[0];

    protected override EventComponent[] Events
    {
        get
        {
            return events;
        }
    }
}