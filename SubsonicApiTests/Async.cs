using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsonicApiTests {
    internal static class Async {
        internal static Task Using<T>(T disposable, Action<T> func) where T : IDisposable {
            return Task.Run(() => func(disposable)).ContinueWith((task) => {
                if (disposable != null) {
                    disposable.Dispose();
                }
                return;
            });
        }

        internal static Task Using<T>(T disposable, Func<T, Task> startTask) where T : IDisposable {
            return startTask(disposable).ContinueWith((task) => {
                if (disposable != null) {
                    disposable.Dispose();
                }
                return;
            });
        }

        internal static Task<TResult> Using<T, TResult>(T disposable, Func<T, TResult> func) where T : IDisposable {
            return Task.Run(() => func(disposable)).ContinueWith((task) => {
                if (disposable != null) {
                    disposable.Dispose();
                }
                return task.Result;
            });
        }

        internal static Task<TResult> Using<T, TResult>(T disposable, Func<T, Task<TResult>> startTask) where T : IDisposable {
            return startTask(disposable).ContinueWith((task) => {
                if (disposable != null) {
                    disposable.Dispose();
                }
                return task.Result;
            });
        }

        internal static AutoDisposingTask<T> AutoDispose<T>(Task<T> task) {
            return new AutoDisposingTask<T>(task);
        }
    }
}
