using System.Collections.Generic;
using System;

public class EventManager
{
    public static EventManager Instance = new EventManager();

    private Dictionary<EventType, Action<EventType>> _events;

    public Dictionary<EventType, Action<EventType>> Events => _events;

    public void Initialize()
    {
        _events = new Dictionary<EventType, Action<EventType>>();
    }

    public void AddListener(EventType eventType, Action<EventType> action)
    {
        if (_events.TryGetValue(eventType, out Action<EventType> value))
        {
            value += action;
            _events[eventType] = value;
        }
        else
        {
            value += action;
            _events.Add(eventType, value);
        }
    }

    public void RemoveListener(EventType eventType, Action<EventType> action)
    {
        if (_events.TryGetValue(eventType, out Action<EventType> value))
        {
            value -= action;
        }
    }
}
