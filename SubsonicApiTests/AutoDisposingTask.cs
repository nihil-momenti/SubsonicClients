using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsonicApiTests {
    internal class AutoDisposingTask<T> {
        private Task<T> _task;
        private T _result;

        internal T Result {
            get {
                AcquireResult();
                return _result;
            }
        }

        private void AcquireResult() {
            if (_task != null) {
                _result = _task.Result;
                _task.Dispose();
                _task = null;
            }
        }

        internal AutoDisposingTask(Task<T> task) {
            _task = task;
        }
    }
}
