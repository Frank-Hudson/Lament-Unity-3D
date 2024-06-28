using System;
using UnityEngine;

public class PlayerInteractible : MonoBehaviour
{
    [SerializeField] private Interaction _interaction;

    public class Interaction
    {
        public Action Action;
    }
}
