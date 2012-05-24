using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubsonicApi.Data;

namespace SubsonicApiTests {
    internal class PropertyComparer : IEqualityComparer<object> {
        public new bool Equals(object x, object y) {
            if (x == null && y == null) {
                return true;
            }
            if (x == null || y == null) {
                return false;
            }

            Type xType = x.GetType();
            Type yType = y.GetType();

            if (xType != yType) {
                return false;
            }

            if (xType.GetCustomAttributes(typeof(CompareByPropertiesAttribute), true).Any()) {
                return xType.GetProperties()
                    .Select(property => property.GetMethod)
                    .Select(getter => Equals(getter.Invoke(x, null), getter.Invoke(y, null)))
                    .Aggregate((b1, b2) => b1 && b2);
            } else if (typeof(IEnumerable).IsAssignableFrom(xType)) {
                return ((IEnumerable)x)
                    .Cast<object>()
                    .Zip(((IEnumerable)y).Cast<object>(), (o1, o2) => Equals(o1, o2))
                    .DefaultIfEmpty(true)
                    .Aggregate((b1, b2) => b1 && b2);
            } else {
                return x.Equals(y);
            }
        }

        public int GetHashCode(object obj) {
            return 0;
        }
    }
}
