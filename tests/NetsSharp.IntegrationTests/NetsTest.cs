namespace NetsSharp.IntegrationTests
{
    using System;
    using System.Threading.Tasks;

    using NetsSharp.Exceptions;

    using Xunit;

    public class NetsTest
    {
        private const string MerchantId = "foo";

        private const string Token = "bar";

        [Fact]
        public async Task CreateOrderSuccessFully()
        {
            var nets = new Nets(MerchantId, Token, new HttpClientApiCaller(), Endpoints.Test);
            var transactionId = await nets.RegisterAsync("12345", 100, "NOK", new RegisterOptions
                {
                    RedirectUrl = new Uri("http://localhost/Test")
                });
            Assert.False(string.IsNullOrEmpty(transactionId));
        }

        [Fact]
        public async Task CreateOrderWithWrongTokens()
        {
            var nets = new Nets("foo", "bar", new HttpClientApiCaller(), Endpoints.Test);
            await Assert.ThrowsAsync<AuthenticationException>(async () => 
                await nets.RegisterAsync("12345", 100, "NOK", new RegisterOptions
                {
                    RedirectUrl = new Uri("http://localhost/Test")
                }));
        }

        [Fact]
        public async Task CreateAndQueryOrder()
        {
            var nets = new Nets(MerchantId, Token, new HttpClientApiCaller(), Endpoints.Test);
            var transactionId = await nets.RegisterAsync("12345", 500, "NOK", new RegisterOptions
            {
                RedirectUrl = new Uri("http://localhost/Test")
            });
            var data = await nets.QueryAsync(transactionId);
            Assert.Equal(500, data.OrderInformation.Total);
            Assert.Equal("NOK", data.OrderInformation.Currency);
        }

        [Fact]
        public async Task RegisterTransaction_WhenTransactionIdAlreadyExists_ShouldThrowUniqueTransactionIdException()
        {
            var transactionId = DateTime.Now.Ticks;
            var nets = new Nets(MerchantId, Token, new HttpClientApiCaller(), Endpoints.Test);
            await nets.RegisterAsync("12345", 500, "NOK", new RegisterOptions
            {
                TransactionId = transactionId.ToString(),
                RedirectUrl = new Uri("http://localhost/Test")
            });

            await Assert.ThrowsAsync<UniqueTransactionIdException>(() => nets.RegisterAsync("12345", 500, "NOK", new RegisterOptions
            {
                TransactionId = transactionId.ToString(),
                RedirectUrl = new Uri("http://localhost/Test")
            }));
        }
    }
}
