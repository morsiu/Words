using System;
using System.Collections.Generic;
using Xunit;

namespace Mors.Words.Test.Infrastructure;

internal sealed class EventRecorder
{
    private readonly List<object> _events = new List<object>();

    public void Record(object @event)
    {
        _events.Add(@event);
    }

    public void AssertRecordedOneEvent<TEvent>(Action<TEvent> eventContentsAssert)
    {
        var @event = Assert.Single(_events);
        Assert.NotNull(@event);
        Assert.Equal(typeof(TEvent), @event.GetType());
        eventContentsAssert((TEvent)@event);
    }

    public void AssertAllEvents(Action<object> eventContentsAssert)
    {
        foreach (var @event in _events)
        {
            eventContentsAssert(@event);
        }
    }
}