using System.Collections.Generic;
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
        { };

        public GameEvent(string name) : base(name)
        { }
    }

    public class DialogueEvent : Event
    {
        public static readonly List<DialogueEvent> Events = new List<DialogueEvent>()
        {
            new DialogueEvent("start", Option<DialogueEvent>.None()),
        };

        private readonly Option<DialogueEvent> parent;
        public Option<DialogueEvent> Parent { get => parent; }

        public DialogueEvent(string name, Option<DialogueEvent> parent) : base(name)
        {
            this.parent = parent;
        }
    }

    private static Event latestEvent;
    public Event GetLatestEvent { get => latestEvent; }

    private static GameEvent latestGameEvent;
    public Event GetLatestGameEvent { get => latestGameEvent; }

    private static DialogueEvent latestDialogueEvent;
    public Event GetLatestDialogueEvent { get => latestDialogueEvent; }
}
