## Application description
The application is intended for integration with Stripe API.
There are two endpoints that make requests to Stripe using restricted key.

GetListBalance endpoint gets balance.
GetPaginatedListBalance endpoint gets paginated transaction list.

## Set up application
Install .NET 6 SDK
Install Visual Studio 2022
Clone repository: gh repo clone Andriets/GenerativeAI_Test
Build solution: dotnet build
Run application: dotnet run

## Example how to use endpoints
GetListBalance endpoint: https://localhost:7055/api/transaction/GetListBalance
GetPaginatedListBalance endpoint: https://localhost:7055/api/transaction/GetPaginatedListBalance/10/txn_3NLsITDxrIeuCSki0jjjiU5U
