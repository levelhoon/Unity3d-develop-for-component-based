using System;
using UnityEngine;

class KeyTrigger : TriggerComponent<IEvent>
{
    [SerializeField]
    Event[] events = new Event[0];

    protected override IEvent[] Events
    {
        get
        {
            return events;
        }
    }

    private void Update()
    {
        InvokeAll();
    }

    private void Awake()
    {
        for (int i = 0; i < events.Length; i++)
        {
            events[i].Init();
        }
    }

    [Serializable]
    class Event : IEvent
    {
        [SerializeField]
        State state = default;
        [SerializeField]
        public KeyCode keyCode = default;
        [SerializeField]
        private EventComponent eventComponent = null;
        [SerializeField]
        public Func<KeyCode, bool> OnKey;

        public void Invoke()
        {
            if (OnKey(keyCode))
            {
                eventComponent.Invoke();
            }
        }

        public void Init()
        {
            switch (state)
            {
                case State.Stay:
                    OnKey = Input.GetKey;
                    break;
                case State.Down:
                    OnKey = Input.GetKeyDown;
                    break;
                case State.Up:
                    OnKey = Input.GetKeyUp;
                    break;
            }
        }
        enum State
        {
            Stay,
            Down,
            Up,
        }
    }
}

