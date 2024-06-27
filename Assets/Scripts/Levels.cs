using UnityEngine;

public class Levels
{
    

    public static class Geometry
    {
        public interface Direction
        {
            public float Value { get; set; }
        }

        public struct X : Direction
        {
            public float Value { get; set; }

            public X(float value)
            {
                this.Value = value;
            }

            public readonly override string ToString() => this.Value.ToString();

            public static implicit operator float(X x) => x.Value;
            public static implicit operator Y(X x) => new Y(x);
            public static implicit operator Z(X x) => new Z(x);
            public static implicit operator W(X x) => new W(x);
            public static explicit operator Vector2(X x) => new Vector2(x, 0);
            public static explicit operator Vector3(X x) => new Vector3(x, 0);
            public static explicit operator Vector4(X x) => new Vector4(x, 0);
        }

        public struct Y : Direction
        {
            public float Value { get; set; }

            public Y(float value)
            {
                this.Value = value;
            }

            public readonly override string ToString() => this.Value.ToString();

            public static implicit operator float(Y y) => y.Value;
            public static implicit operator X(Y y) => new X(y);
            public static implicit operator Z(Y y) => new Z(y);
            public static implicit operator W(Y y) => new W(y);
            public static explicit operator Vector2(Y y) => new Vector2(0, y);
            public static explicit operator Vector3(Y y) => new Vector3(0, y);
            public static explicit operator Vector4(Y y) => new Vector4(0, y);
        }

        public struct Z : Direction
        {
            public float Value { get; set; }

            public Z(float value)
            {
                this.Value = value;
            }

            public readonly override string ToString() => this.Value.ToString();

            public static implicit operator float(Z z) => z.Value;
            public static implicit operator X(Z z) => new X(z);
            public static implicit operator Y(Z z) => new Y(z);
            public static implicit operator W(Z z) => new W(z);
            public static explicit operator Vector3(Z z) => new Vector3(0, 0, z);
            public static explicit operator Vector4(Z z) => new Vector4(0, 0, z);
        }

        public struct W : Direction
        {
            public float Value { get; set; }

            public W(float value)
            {
                this.Value = value;
            }

            public readonly override string ToString() => this.Value.ToString();

            public static implicit operator float(W w) => w.Value;
            public static implicit operator X(W w) => new X(w);
            public static implicit operator Y(W w) => new Y(w);
            public static implicit operator Z(W w) => new Z(w);
            public static explicit operator Vector4(W w) => new Vector4(0, 0, 0, w);
        }
    }
}
