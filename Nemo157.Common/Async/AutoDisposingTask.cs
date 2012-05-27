using System.Threading.Tasks;

namespace Nemo157.Common {
    public class AutoDisposingTask<T> {
        private Task<T> _task;
        private T _result;

        public T Result {
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

        public AutoDisposingTask(Task<T> task) {
            _task = task;
        }
    }
}
