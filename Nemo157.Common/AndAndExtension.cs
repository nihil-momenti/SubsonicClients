using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemo157.Common {
    public static class AndAndExtension {
        private class NullStub<T> : DynamicObject {
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {
                result = null;
                return MethodExists(binder.AndAnd().Name, args.Select(arg => arg.GetType()).ToArray());
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result) {
                result = null;
                return MemberExists(binder.AndAnd().Name);
            }

            private static bool MethodExists(string memberName, Type[] args) {
                return memberName != null && args != null && typeof(T).GetMethod(memberName, args) != null;
            }

            private static bool MemberExists(string memberName) {
                return memberName != null && typeof(T).GetMember(memberName) != null;
            }
        }

        public static dynamic AndAnd<T>(this T obj) {
            return (dynamic)obj ?? new NullStub<T>();
        }
    }
}
