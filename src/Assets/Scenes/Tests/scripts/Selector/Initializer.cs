using System.Collections.Generic;

namespace System.Helpers
{
    internal static class Initializer
    {
        /// <summary>Инициализирует инстанс списка.</summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="unit"></param>
        internal static void Initialize<Type>(ref List<Type> unit, int capacity = 4)
            => unit = new List<Type>(capacity: capacity);
    }
}

