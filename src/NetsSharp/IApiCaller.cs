namespace NetsSharp
{
    using System;
    using System.Threading.Tasks;

    internal interface IApiCaller
    {
        Task<TResponse> CallAsync<TResponse>(Uri endpoint);
    }
}