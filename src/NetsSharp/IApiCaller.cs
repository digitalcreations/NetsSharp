namespace NetsSharp
{
    using System;
    using System.Threading.Tasks;

    interface IApiCaller
    {
        Task<TResponse> CallAsync<TResponse>(Uri endpoint);
    }
}