# NetsSharp

NetsSharp is a portable C# wrapper for [the Nets REST API](https://shop.nets.eu/web/partners/appi).

It simplifies using their payment services greatly. You will need to be familiar with how their API works for this library to make sense.

## Installation

Use Nuget:

```
> Install-Package NetsSharp
```

## Using

```cs
var nets = NetsSharp.Nets.Create(
    "merchant id", 
    "token", 
    NetsSharp.Endpoints.Live);
var transactionId = await nets.RegisterAsync("order1", 100, "NOK",
    new RegisterOptions {
        RedirectUri = new Uri("http://localhost/return_from_nets")
    });
var terminalUri = nets.GetTerminalEndpoint(transactionId);
// Now redirect the user's browser to terminalUri.

// When the user hits the RedirectUri above:
await nets.SaleAsync(transactionId);
```

### Crediting transaction

```cs
// partial refund:
await nets.CreditAsync(transactionId, 
    new ProcessRequestOptions {
        TransactionAmount = 100,
        Description = "Refund because of downtime"
    });

// full refund
await nets.CreditAsync(transactionId);
```

### Querying transactions

```cs
var information = await nets.QueryAsync(transactionId);
```

### Exceptions

If something goes wrong, we throw exceptions. Exceptions are named after the documentation, and are all in the `NetsSharp.Exceptions` namespace.

### Merchant hosted

```cs
var nets = NetsSharp.Nets.Create(
    "merchant id", 
    "token", 
    NetsSharp.Endpoints.Live);
var transactionId = await nets.RegisterAsync("order1", 100, "NOK",
    new RegisterOptions {
        RedirectUri = new Uri("http://localhost/return_from_nets"),
        ServiceType = ServiceType.MerchantHosted
    });
```

### Parsing response codes

Nice little snippet for easily parsing the response code when the user is redirected back to you:

```cs
try
{
    if (Nets.InterpretResponseCode(responseCode)) 
    {
        await nets.SaleAsync(transactionId);
        // grant backend access to whatever resources you need
    }
}
catch (InvalidResponseException e) {
    // inspect e.Errors to see which fields had which mistakes.
}
```

## Monetary units

All amounts are given and expected to be in the lowest currency denomination. For dollars, this would be cents. For Norwegian kroner, this would be øre. This means you will probably have to multiply any amount you display to the user by 100.

## Integration tests

If you want to run the integration tests, you will need a test account to run against.

## Caveats

This wrapper is not complete. There are several parts of the API we haven't had use for, so we simply haven't implemented it.

Pull requests welcome.

## About

This is an unofficial library made by [Digital Creations AS](http://www.digitalcreations.no). This library is not affiliated with, endorsed or supported by Nets in any way. 