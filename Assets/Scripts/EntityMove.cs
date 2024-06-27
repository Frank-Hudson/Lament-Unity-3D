using System.Collections.Generic;
using System.ComponentModel;
using OneOf;
using UnityEngine;

public class EntityMove : MonoBehaviour
{
    [SerializeField] private List<OneOf<Movement, Vector3>> _movementsPath;

    public struct Movement
    {
        public Axis axis;
        public float distance;

        public static implicit operator Vector3(Movement _) => _.axis switch
        {
            Axis.X => new Vector3(_.distance, 0, 0),
            Axis.Y => new Vector3(0, _.distance, 0),
            Axis.Z => new Vector3(0, 0, _.distance),
            _ => throw new InvalidEnumArgumentException("The Axis enum can only be X, Y, or Z"),
        };
    }

    public enum Axis { X, Y, Z }
}
