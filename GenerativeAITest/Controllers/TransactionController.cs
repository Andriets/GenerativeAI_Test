using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace GenerativeAITest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TransactionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetListBalance")]
        public IActionResult GetListBalance()
        {
            try
            {
                var stripeApiKey = _configuration["StripeApiKeyWrite"];

                StripeConfiguration.ApiKey = stripeApiKey;
                var balanceService = new BalanceService();
                var balance = balanceService.Get();

                return Ok(balance);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetPaginatedListBalance/{limit}/{startingafter}")]
        public IActionResult GetPaginatedListBalance(long? limit, string startingAfter)
        {
            try
            {
                var stripeApiKey = _configuration["StripeApiKeyWrite"];

                StripeConfiguration.ApiKey = stripeApiKey;
                var balanceTransactionOptions = new BalanceTransactionListOptions
                {
                    Limit = limit,
                    StartingAfter = startingAfter,
                };

                var balanceTransactionService = new BalanceTransactionService();
                var transactionList = balanceTransactionService.List(balanceTransactionOptions);

                return Ok(transactionList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
