using System;
using System.Collections;
using UnityEngine;

class TimerTrigger : TriggerComponent<IEvent>
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


    private void OnEnable()
    {
        InvokeAll();
    }

    private void Awake()
    {
        for (int i = 0; i < events.Length; i++)
        {
            events[i].Init(this);
        }
    }

    [Serializable]
    class Event : IEvent
    {
        [SerializeField]
        bool loop = default;
        [SerializeField]
        float sec = 1;
        [SerializeField]
        private EventComponent eventComponent = null;
        TimerTrigger timer;
        public float Sec
        {
            get
            {
                return sec;
            }
        }


        IEnumerator Wait()
        {
            do
            {
                yield return new WaitForSeconds(Sec);
                eventComponent.Invoke();
            } while (loop);
        }

        public void Invoke()
        {
            timer.StartCoroutine(Wait());
        }

        public void Init(TimerTrigger timer)
        {
            this.timer = timer;
        }
    }
}
