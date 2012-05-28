using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;

namespace Nemo157.Common {
    public class EqualByPropertyConstraint : Constraint {
        private object _expectedResponse;
        private List<Failure> _failures;

        public EqualByPropertyConstraint(object expectedResponse) 
            : base(expectedResponse) {
            _expectedResponse = expectedResponse;
        }

        public override bool Matches(object actual) {
            this.actual = actual;
            _failures = new List<Failure>();
            PropertyEquals(_expectedResponse, actual, _expectedResponse.GetType().Name);
            return _failures.IsEmpty();
        }

        public override void WriteDescriptionTo(MessageWriter writer) {
            if (writer != null) {
                writer.WriteMessageLine("Equal By Property Constraint");
            }
        }

        public override void WriteMessageTo(MessageWriter writer) {
            if (writer != null) {
                foreach (var failure in _failures) {
                    failure.WriteMessageTo(writer);
                }
            }
        }

        public void PropertyEquals(object expected, object actual, string path) {
            if (expected == null && actual == null) {
                return;
            }
            if (expected == null || actual == null) {
                _failures.Add(new ValueFailure { Path = path, Expected = expected, Actual = actual });
                return;
            }

            Type expectedType = expected.GetType();
            Type actualType = actual.GetType();

            if (expectedType != actualType) {
                _failures.Add(new TypeFailure { Path = path, ExpectedType = expectedType, ActualType = actualType });
                return;
            }

            if (expectedType.GetCustomAttributes(typeof(CompareByPropertiesAttribute), true).Any()) {
                foreach (var property in expectedType.GetProperties().Select(property => new { Name = property.Name, Getter = property.GetMethod })) {
                    PropertyEquals(property.Getter.Invoke(expected, null), property.Getter.Invoke(actual, null), path + "." + property.Name);
                }
            } else if (expectedType == typeof(string)) {
                string expectedString = (string)expected;
                string actualString = (string)actual;
                if (!(expectedString).Equals(actualString, StringComparison.Ordinal)) {
                    _failures.Add(new StringFailure { Path = path, Expected = expectedString, Actual = actualString });
                }
            } else if (typeof(IEnumerable).IsAssignableFrom(expectedType)) {
                IEnumerable<object> expectedEnumerable = ((IEnumerable)expected).Cast<object>();
                IEnumerable<object> actualEnumerable = ((IEnumerable)actual).Cast<object>();
                PropertyEquals(expectedEnumerable.Count(), actualEnumerable.Count(), path + ".Count");
                foreach (var pair in expectedEnumerable.Zip(actualEnumerable).Select((pair, index) => new { Index = index, Pair = pair })) {
                    PropertyEquals(pair.Pair.Key, pair.Pair.Value, path + "[" + pair.Index + "]");
                }
            } else {
                if (!expected.Equals(actual)) {
                    _failures.Add(new ValueFailure { Path = path, Expected = expected, Actual = actual });
                }
            }
        }

        private abstract class Failure {
            public string Path { get; set; }

            public abstract void WriteMessageTo(MessageWriter writer);
        }

        private class ValueFailure : Failure {
            public object Expected { get; set; }
            public object Actual { get; set; }

            public override void WriteMessageTo(MessageWriter writer) {
                writer.WriteMessageLine("Difference at {0}", Path);
                writer.DisplayDifferences(Expected, Actual);
            }
        }

        private class StringFailure : Failure {
            public string Expected { get; set; }
            public string Actual { get; set; }

            public override void WriteMessageTo(MessageWriter writer) {
                writer.WriteMessageLine("Difference at {0}", Path);
                writer.DisplayStringDifferences(Expected, Actual, Expected.Zip(Actual, (c1, c2) => c1 == c2).ToList().IndexOf(false), false, true);
            }
        }

        private class TypeFailure : Failure {
            public Type ExpectedType { get; set; }
            public Type ActualType { get; set; }

            public override void WriteMessageTo(MessageWriter writer) {
                writer.WriteMessageLine("Different types at {0}", Path);
                writer.DisplayDifferences(ExpectedType, ActualType);
            }
        }
    }
}
