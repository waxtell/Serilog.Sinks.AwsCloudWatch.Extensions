using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Hosting
{
    public static class HostBuilderExtensions
    {
        public static async Task RunConsoleAsync<T>(this IHost host, Func<T, Task> worker)
        {
            await worker.Invoke(host.Services.GetService<T>());
        }
    }
}