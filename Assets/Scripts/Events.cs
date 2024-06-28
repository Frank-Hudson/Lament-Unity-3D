using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Events : MonoBehaviour
{
    public abstract class Event
    {
        private readonly string name;
        public string Name { get => name; }

        public Event(string name)
        {
            this.name = name;
        }
    }

    public class GameEvent : Event
    {
        public static readonly List<GameEvent> Events = new List<GameEvent>()
        {
            new GameEvent("blob1-move"),
        };

        public static GameEvent FindEvent(string name) => Events.Find(ev => ev.Name == name);

        public GameEvent(string name) : base(name)
        { }
    }

    public class DialogueEvent : Event
    {
        public static readonly List<DialogueEvent> Events = new List<DialogueEvent>()
        {
            new DialogueEvent("start", Option<DialogueEvent>.None()),
        };

        public static DialogueEvent FindEvent(string name) => Events.Find(ev => ev.Name == name);

        private readonly Option<DialogueEvent> parent;
        public Option<DialogueEvent> Parent { get => parent; }

        public DialogueEvent(string name, Option<DialogueEvent> parent) : base(name)
        {
            this.parent = parent;
        }
    }

    private static Event _latestEvent;
    public static Event GetLatestEvent() => _latestEvent;

    private static GameEvent _latestGameEvent;
    public static GameEvent GetLatestGameEvent() => _latestGameEvent;

    private static DialogueEvent _latestDialogueEvent;
    public static DialogueEvent GetLatestDialogueEvent() => _latestDialogueEvent;
}
