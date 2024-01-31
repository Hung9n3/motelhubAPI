using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public static class NumberExtension
{
    /// <summary>
    /// check if the given number is null or less than or equal zero
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsPositive(this IComparable? value)
    {
        return value != null && value.CompareTo(default) == 1;
    }
}
