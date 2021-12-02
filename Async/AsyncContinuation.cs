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
            var and = await Task.Run(() =>
            {
                string someString = string.Empty;

                //Some useless function that is cancellable
                for (int i = 0; i < 200000; i++)
                {
                    someString += "a";
                    if (cToken.IsCancellationRequested) break;
                    //cToken.ThrowIfCancellationRequested();
                }

                return "And";
            }, cToken);

            var again = await Task.Run(async() =>
            {
                await Task.Delay(1000); 
                return "again";
            });

            return $"{and} {again}";
        }
    }

}