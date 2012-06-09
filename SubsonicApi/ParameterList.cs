using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace SubsonicApi {
    internal class ParameterList : IEnumerable<Parameter> {
        private List<Parameter> _parameters;

        public ParameterList() {
            _parameters = new List<Parameter>();
        }

        public object this[string field] {
            set {
                if (value != null) {
                    _parameters.Add(new Parameter { Name = field, Value = value, Type = ParameterType.GetOrPost });
                }
            }
        }

        public IEnumerator<Parameter> GetEnumerator() {
            return _parameters.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
