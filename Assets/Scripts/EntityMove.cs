using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Events.GameEvent _trigger;
    [SerializeField] private List<Vector3> _movementsPath;

    private EntityData _entityData;

    private void Awake()
    {
        _entityData = GetComponent<EntityData>();
        _speed = _entityData.Character.CharacterData.speed;
    }

    private void Update()
    {
        if (Events.GetLatestGameEvent() == _trigger)
        {
            foreach (Vector3 movement in _movementsPath)
            {
                Delay(3, () => transform.Translate(movement * _speed * Time.deltaTime));
            }
        }
    }

    private void Delay(int seconds, Action action)
    {
        StartCoroutine(SleepForSecondsThenDo(seconds, action));
    }

    private IEnumerator SleepForSecondsThenDo(int seconds, Action thenDo)
    {
        yield return new WaitForSeconds(seconds);
        thenDo();
    }
}
