using UnityEngine;

abstract class EventComponent : MonoBehaviour, IEvent
{
    public abstract void Invoke();
}

interface IEvent
{
    void Invoke();
}

interface IEvent<T> : IEvent
{
    T Handle { get; }
}