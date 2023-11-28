using Microsoft.AspNetCore.Mvc;
using BillsPaymentSystem.API.DTO;
using BillsPaymentSystem.Core.BillerAgents;
using Microsoft.AspNetCore.Authorization;

namespace BillsPaymentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillerAgent _services;

        public BillsController(IBillerAgent services)
        {
            _services = services;
        }

        //GET: api/<BillsController>
        //[Authorize]
        [HttpGet("get-bills")]
        public async Task<IActionResult> ListBills()
        {
            try
            {
                var bills = await _services.GetBills();
                var billsDto = bills.Select(bill => new BillDto
                {
                    BillID = bill.BillID,
                    BillName = bill.BillName,
                    Amount = bill.Amount,
                });

                return bills != null ? Ok(billsDto) : NotFound("No bills found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
