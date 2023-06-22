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
    }
}
