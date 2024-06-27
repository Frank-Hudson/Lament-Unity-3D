using System;

/// Optional wrapper type (interface union).
public abstract class Option<T>
{
    /// <summary>
    /// Returns <c>true</c> if the option is a <c>Some</c> value.
    /// </summary>
    public abstract bool IsSome();
    /// <summary>
    /// Returns <c>true</c> if the option is a <c>Some</c> and the value inside of it matches a predicate.
    /// </summary>
    public abstract bool IsSomeAnd(Func<T, bool> f);
    /// <summary>
    /// Returns <c>true</c> if the option is a <c>None</c> value.
    /// </summary>
    public abstract bool IsNone();

    /// <summary>
    /// Returns the value if it is Some, else throw a NoneOptionException
    /// </summary>
    /// <example>
    /// <code>
    /// Option<int> myOptional1 = Option.Some(2);
    /// Option<int> myOptional2 = Option.None;
    /// 
    /// int myResult1 = myOptional1.Expect("this should be fine");
    /// int myResult2 = myOptional2.Expect("this will throw a NoneOptionException witht the provided msg");
    /// </code>
    /// </example>
    public abstract T Expect(string msg);

    public abstract T Unwrap();
    public abstract T UnwrapOr(T defaultValue);
    public abstract T UnwrapOrElse(Func<T> f);

    /// <summary>
    /// Maps an Option<T> to Option<U> by applying a function to a contained value (if Some) or returns None (if None).
    /// </summary>
    public abstract Option<U> Map<U>(Func<T, U> f);
    /// <summary>
    /// Returns the provided default result (if none), or applies a function to the contained value (if any).
    ///
    /// <para>Arguments passed to <c>MapOr</c> are eagerly evaluated; if you are passing the result of a function call, it is recommended to use <c>MapOrElse</c>, which is lazily evaluated.</para>
    /// </summary>
    public abstract U MapOr<U>(U defaultValue, Func<T, U> f);
    /// <summary>
    /// Computes a default function result (if none), or applies a different function to the contained value (if any).
    /// </summary>
    public abstract U MapOrElse<U>(Func<U> defaultValue, Func<T, U> f);

    /// <summary>
    /// Calls a function with a reference to the contained value if Some.
    ///
    /// <para>Returns the original option.</para>
    /// </summary>
    public abstract Option<T> Inspect(Action<T> f);

    /// <summary>
    /// Returns None if the option is None, otherwise returns optb.
    /// 
    /// <para>Arguments passed to <c>And</c> are eagerly evaluated; if you are passing the result of a function call, it is recommended to use <c>AndThen</c>, which is lazily evaluated.</para>
    /// </summary>
    public abstract Option<U> And<U>(Option<U> optb);
    /// <summary>
    /// Returns None if the option is None, otherwise calls <c>f</c> with the wrapped value and returns the result.
    ///
    /// <para>Some languages call this operation flatmap.</para>
    /// </summary>
    public abstract Option<U> AndThen<U>(Func<T, Option<U>> f);

    /// <summary>
    /// Returns None if the option is None, otherwise calls predicate with the wrapped value and returns:
    ///
    /// <list type="bullet">
    ///     <item><description>Some(t) if predicate returns true (where t is the wrapped value), and</description></item>
    ///     <item><description>None if predicate returns false.</description></item>
    /// </list>
    /// </summary>
    public abstract Option<T> Filter(Func<T, bool> predicate);

    /// <summary>
    /// Returns the option if it contains a value, otherwise returns optb.
    ///
    /// <para>Arguments passed to or are eagerly evaluated; if you are passing the result of a function call, it is recommended to use or_else, which is lazily evaluated.</para>
    /// </summary>
    public abstract Option<T> Or(Option<T> optb);
    /// <summary>
    /// Returns the option if it contains a value, otherwise calls <c>f</c> and returns the result.
    /// </summary>
    public abstract Option<T> OrElse(Func<Option<T>> f);
    /// <summary>
    /// Returns <c>Some</c> if exactly one of <c>self</c>, <c>optb</c> is <c>Some</c>, otherwise returns <c>None</c>.
    /// </summary>
    public abstract Option<T> Xor(Option<T> optb);


    /// No value
#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
    public static Option<T> None<T>() => new NoneType<T>();
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
    public static Option<T> None() => new NoneType<T>();

    /// Some value of type T
#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
    public static Option<T> Some<T>(T value) => new SomeType<T>(value);
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
    public static Option<T> Some(T value) => new SomeType<T>(value);


    /// Value-present variant of `Option`.
#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
    public class SomeType<T> : Option<T>
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
    {
        private T value;

        public SomeType(T value)
        {
            this.value = value;
        }

        public override bool IsSome() => true;
        public override bool IsSomeAnd(Func<T, bool> f) => true && f(value);
        public override bool IsNone() => false;

        public override T Expect(string msg) => value;

        public override T Unwrap() => value;
        public override T UnwrapOr(T defaultValue) => value;
        public override T UnwrapOrElse(Func<T> f) => value;

        public override Option<U> Map<U>(Func<T, U> f) => new SomeType<U>(f(value));
        public override U MapOr<U>(U defaultValue, Func<T, U> f) => f(value);
        public override U MapOrElse<U>(Func<U> defaultValue, Func<T, U> f) => f(value);

        public override Option<T> Inspect(Action<T> f)
        {
            f(value);
            return this;
        }

        public override Option<U> And<U>(Option<U> optb) => optb;
        public override Option<U> AndThen<U>(Func<T, Option<U>> f) => f(value);

        public override Option<T> Filter(Func<T, bool> predicate) => predicate(value) switch
        {
            true => this,
            false => None<T>(),
        };

        public override Option<T> Or(Option<T> optb) => this;
        public override Option<T> OrElse(Func<Option<T>> f) => this;
        public override Option<T> Xor(Option<T> optb)
        {
            if (this.IsSome() && optb.IsNone()) return Some(this.value);
            else if (this.IsNone() && optb.IsSome()) return Some(((SomeType<T>)optb).value);
            else return None<T>();
        }
    }


    /// Value-absent variant of `Option`
#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
    public class NoneType<T> : Option<T>
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
    {
        public override bool IsSome() => false;
        public override bool IsSomeAnd(Func<T, bool> f) => false;
        public override bool IsNone() => true;

        public override T Expect(string msg) => throw new NoneOptionException(message: msg);

        public override T Unwrap() => throw new NoneOptionException();
        public override T UnwrapOr(T defaultValue) => defaultValue;
        public override T UnwrapOrElse(Func<T> f) => f();

        public override Option<U> Map<U>(Func<T, U> f) => None<U>();
        public override U MapOr<U>(U defaultValue, Func<T, U> f) => defaultValue;
        public override U MapOrElse<U>(Func<U> defaultValue, Func<T, U> f) => defaultValue();

        public override Option<T> Inspect(Action<T> f) => this;

        public override Option<U> And<U>(Option<U> optb) => None<U>();
        public override Option<U> AndThen<U>(Func<T, Option<U>> f) => None<U>();

        public override Option<T> Filter(Func<T, bool> predicate) => None<T>();

        public override Option<T> Or(Option<T> optb) => optb;
        public override Option<T> OrElse(Func<Option<T>> f) => f();
        public override Option<T> Xor(Option<T> optb) => None<T>();
    }

    [Serializable]
    public class OptionException : Exception
    {
        public OptionException() { }
        public OptionException(string message) : base(message) { }
        public OptionException(string message, Exception inner) : base(message, inner) { }
        protected OptionException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class NoneOptionException : OptionException
    {
        public NoneOptionException() { }
        public NoneOptionException(string message) : base(message) { }
        public NoneOptionException(string message, Exception inner) : base(message, inner) { }
        protected NoneOptionException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
