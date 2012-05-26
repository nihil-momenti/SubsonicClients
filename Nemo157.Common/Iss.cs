using System.Diagnostics.CodeAnalysis;
using NUnit.Framework.Constraints;

namespace Nemo157.Common {
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Iss")]
    public static class Iss {
        public static Constraint EqualByPropertyTo(object expectedResponse) {
            return new EqualByPropertyConstraint(expectedResponse);
        }
    }
}
