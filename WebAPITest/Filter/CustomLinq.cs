using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Filter
{
    public static class CustomLinq
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            var result = new List<T>();
            foreach (var item in source) {
                if (predicate(item))
                    yield return item;
            }
        }
    }
}
