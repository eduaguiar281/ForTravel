using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.ForTravel.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static void ForEach<T>(this IList<T> list, Action<T> function)
        {
            foreach(var item in list)
            {
                function(item);
            }
        }
    }
}
