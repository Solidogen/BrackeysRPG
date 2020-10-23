using System;

public static class LanguageUtils
{
    public static void Run<T>(this T self, Action<T> block)
    {
        /* 
            Check if Unity Object was destroyed.
            "Destroyed" T as C# object is not null, but as UnityEngine.Object it will be null because of Equals override.
         */
        if ((UnityEngine.Object)(object)self == null)
        {
            return;
        }
        block(self);
    }

    public static R Let<T, R>(this T self, Func<T, R> block)
    {
        /* 
            Check if Unity Object was destroyed.
            "Destroyed" T as C# object is not null, but as UnityEngine.Object it will be null because of Equals override.
         */
        if ((UnityEngine.Object)(object)self == null)
        {
            return default;
        }
        return block(self);
    }

    public static T Also<T>(this T self, Action<T> block)
    {
        /* 
            Check if Unity Object was destroyed.
            "Destroyed" T as C# object is not null, but as UnityEngine.Object it will be null because of Equals override.
         */
        if ((UnityEngine.Object)(object)self == null)
        {
            return default;
        }
        block(self);
        return self;
    }
}
