using System.Runtime.CompilerServices;

namespace StringCalculator;

internal static class Helpers
{
    public delegate void ForEachAction<in T>(T item, int index);
    //public static void ForEach<T>(this IEnumerable<T> list, ForEachAction<T> action) 
    //{
    //    for (int i = 0; i < list.Count(); i++)
    //    {
    //        action.Invoke(list.ElementAt(i), i);
    //    }
    //}

    //public static void ForEach<T>(this T[] array, ForEachAction<T> action)
    //{
    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        action.Invoke(array[i], i);
    //    }
    //}
}
