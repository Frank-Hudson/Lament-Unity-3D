using System.Collections.Generic;
using OneOf;
using OneOf.Types;
using UnityEngine;

public class Events : MonoBehaviour
{
    private static Event _latestEvent;
    public static Event GetLatestEvent() => _latestEvent;

    private static GameEvent _latestGameEvent;
    public static GameEvent GetLatestGameEvent() => _latestGameEvent;
    public static void SetGameEvent(GameEvent gameEvent)
    {
        _latestGameEvent = gameEvent;
        _latestEvent = gameEvent;
    }

    private static DialogueEvent _latestDialogueEvent;
    public static DialogueEvent GetLatestDialogueEvent() => _latestDialogueEvent;
    public static void SetDialogueEvent(DialogueEvent dialogueEvent)
    {
        _latestDialogueEvent = dialogueEvent;
        _latestEvent = dialogueEvent;
    }

    private void Start() {
        SetDialogueEvent(DialogueEvent.Events[0]);
    }

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
        public static readonly List<GameEvent> Events = new List<GameEvent>
        {
            new GameEvent("blob1-move"),
        };

        public static GameEvent FindEvent(string name) => Events.Find(ev => ev.Name == name);

        public GameEvent(string name) : base(name)
        { }
    }

    public class DialogueEvent : Event
    {
        public static readonly List<DialogueEvent> Events = new List<DialogueEvent>
        {
            new DialogueEvent("start", new None()),
        };

        public static DialogueEvent FindEvent(string name) => Events.Find(ev => ev.Name == name);

        private readonly OneOf<Event, None> parent;
        public OneOf<Event, None> Parent { get => parent; }

        public DialogueEvent(string name, OneOf<Event, None> parent) : base(name)
        {
            this.parent = parent;
        }
    }
}
