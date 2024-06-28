using Newtonsoft.Json;
using OneOf;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionAssets : MonoBehaviour
{
    [SerializeField] private TextAsset _actionsAsset;

    private List<Action> _actions;
    public List<Action> Actions { get => _actions; }

    public Action FindAction(string name) => _actions.Find(x => x.name == name);

    private void Awake()
    {
        _actions = JsonConvert.DeserializeObject<List<Action>>(_actionsAsset.text);
    }

    [Serializable]
    public class Action
    {
        public string name;
        public GameTimeLength length;
        public OneOf<ActionType, SpecialActionType> type;
    }

    [Serializable]
    public struct GameTimeLength
    {
        public int amount;
        public GameTimeUnit period;
    }

    [Serializable]
    public enum GameTimeUnit
    {
        action,
        bonus_action,
        reaction,
        minutes,
        hours,
        days,
    }

    [Serializable]
    public enum ActionType
    {
        dash,
        disengage,
        dodge,
        help,
        hide,
        ready,
        search,
        useobject,
    }

    [Serializable]
    public enum SpecialActionTypeValues
    {
        attack,
    }

    [Serializable]
    public struct SpecialActionType
    {
        SpecialActionTypeValues type;
        List<Roll> rolls;
    }

    public const KeyCode INTERACT_KEY = KeyCode.E;
}
