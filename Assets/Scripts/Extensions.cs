using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static string AllToString<T>(this IEnumerable<T> list)
    {
        string str = "";
        foreach (var item in list)
        {
            str += item.ToString() + "\n";
        }
        return str;
    }
}
