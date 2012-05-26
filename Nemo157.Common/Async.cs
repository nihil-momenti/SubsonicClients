using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Nemo157.Common {
    public static class Async {
        public static Task Using<T>(T disposable, Action<T> func) where T : IDisposable {
            if (func == null) {
                throw new ArgumentNullException("func");
            }
            return Task.Run(() => func(disposable)).ContinueWith((task) => {
                if (disposable != null) {
                    disposable.Dispose();
                }
                return;
            });
        }

        public static Task Using<T>(T disposable, Func<T, Task> startTask) where T : IDisposable {
            if (startTask == null) {
                throw new ArgumentNullException("startTask");
            }
            return startTask(disposable).ContinueWith((task) => {
                if (disposable != null) {
                    disposable.Dispose();
                }
                return;
            });
        }

        public static Task<TResult> Using<T, TResult>(T disposable, Func<T, TResult> func) where T : IDisposable {
            if (func == null) {
                throw new ArgumentNullException("func");
            }
            return Task.Run(() => func(disposable)).ContinueWith((task) => {
                if (disposable != null) {
                    disposable.Dispose();
                }
                return task.Result;
            });
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TResult> Using<T, TResult>(T disposable, Func<T, Task<TResult>> startTask) where T : IDisposable {
            if (startTask == null) {
                throw new ArgumentNullException("startTask");
            }
            return startTask(disposable).ContinueWith((task) => {
                if (disposable != null) {
                    disposable.Dispose();
                }
                return task.Result;
            });
        }

        public static AutoDisposingTask<T> AutoDispose<T>(Task<T> task) {
            return new AutoDisposingTask<T>(task);
        }
    }
}
