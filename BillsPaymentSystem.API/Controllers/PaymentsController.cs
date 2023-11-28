using BillsPaymentSystem.API.DTO;
using BillsPaymentSystem.Core.BillerAgents;
using BillsPaymentSystem.Core.DTO;
using BillsPaymentSystem.Core.Services;
using BillsPaymentSystem.DAL.Data;
using BillsPaymentSystem.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BillsPaymentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IBillerAgent _services;
        private readonly IPaymentService _paymentservice;
        private readonly BillPaymentDbContext _context;

        public PaymentsController(IBillerAgent services, BillPaymentDbContext context, IPaymentService paymentservice)
        {
            _services = services;
            _context = context;
            _paymentservice = paymentservice;
        }

        // GET api/<PaymentsController>/5
        //[Authorize]
        [HttpGet("payment-history")]
        public async Task<ActionResult<List<Payment>>> GetPaymentHistory()
        {
            var paymentHistory = await _paymentservice.GetPaymentHistoryAsync();
            var paymentHistoryDTOs = paymentHistory.Select(history => new PaymentHistoryDto
            {
                PaymentID = history.PaymentID,
                BillName = history.Bill?.BillName ?? "Unknown", // Default to "Unknown" if Bill is null
                PaymentAmount = history.Amount,
                PaymentDate = history.PaymentDate
            });

            if (paymentHistory == null)
            {
                return BadRequest("No payment found");
            }

            return Ok(paymentHistoryDTOs);
        }

        // POST api/<PaymentsController>
        //[Authorize]
        [HttpPost("save-payment")]
        public async Task<IActionResult> PayBill([FromBody] PaymentDto payment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Check if the bill exists.
                    var bill = await _context.Bills.FindAsync(payment.BillID);
                    if (bill == null)
                    {
                        return BadRequest("Bill not found.");
                    }

                    // Check if the payment amount is sufficient
                    if (payment.Amount < bill.Amount)
                    {
                        return BadRequest("Underpayment not acceptable.");
                    }

                    await _services.SubmitPayment(payment);
                    return Ok("Payment saved successfully.");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

    }
}
