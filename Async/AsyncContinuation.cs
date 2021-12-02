using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace GitGoodScrub
{
    public static class Async
    {
        public static string GetMessageAsyncChain() 
        {
            var task = Task.Run(() => "Hello")
            .ContinueWith((previous) => $"{previous.Result} there");

            return task.Result;
        }

        public static async Task<string> GetMessageAsyncAwaitCancellable(CancellationToken cToken) 
        {
            var hello = await Task.Run(() =>
            {
                string someString = string.Empty;

                //Some useless function that is cancellable
                for (int i = 0; i < 100000; i++)
                {
                    someString += "a";
                    if (cToken.IsCancellationRequested) break;
                    //cToken.ThrowIfCancellationRequested();
                }

                return "Hello";
            }, cToken);

            var again = await Task.Run(async() =>
            {
                await Task.Delay(500); 
                return "again";
            });

            return $"{hello} {again}";
        }

        public static async IAsyncEnumerable<Toy> AsyncEnumerableToyStream([EnumeratorCancellation] CancellationToken cToken = default)
        {
            yield return new Toy() { Name = "Present1"};

            await Task.Delay(500, cToken);
            yield return new Toy() { Name = "Present2"};

            await Task.Delay(500, cToken);
            yield return new Toy() { Name = "Present3"};
        }
    }

}