using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Nemo157.Common {
    public static class ExtensionMethods {
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static IEnumerable<KeyValuePair<T1, T2>> Zip<T1, T2>(this IEnumerable<T1> list1, IEnumerable<T2> list2) {
            return list1.Zip(list2, (item1, item2) => new KeyValuePair<T1, T2>(item1, item2));
        }

        public static IEnumerable<TResult> Zip<T1, T2, TResult>(this IEnumerable<T1> list1, IEnumerable<T2> list2, Func<int, T1, T2, TResult> transform) {
            return list1.Select((item, index) => new { Index = index, Item = item }).Zip(list2, (item1, item2) => transform(item1.Index, item1.Item, item2));
        }

        public static bool IsEmpty<T>(this IEnumerable<T> list) {
            return !list.Any();
        }
    }
}
