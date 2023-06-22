using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace GenerativeAITest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly BalanceService _balanceService;
        private readonly BalanceTransactionService _balanceTransactionService;

        public TransactionController(IConfiguration configuration, 
            BalanceService balanceService,
            BalanceTransactionService balanceTransactionService)
        {
            _configuration = configuration;
            _balanceService = balanceService;
            _balanceTransactionService = balanceTransactionService;
        }

        [HttpGet]
        [Route("GetListBalance")]
        public IActionResult GetListBalance()
        {
            try
            {
                var stripeApiKey = _configuration["StripeApiKeyWrite"];

                StripeConfiguration.ApiKey = stripeApiKey;
                var balance = _balanceService.Get();

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

                var transactionList = _balanceTransactionService.List(balanceTransactionOptions);

                return Ok(transactionList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
