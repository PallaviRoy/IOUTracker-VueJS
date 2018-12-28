using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackYourIOU.Models;

namespace TrackYourIOU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Loans
        [HttpGet]
        public IEnumerable<Loan> GetLoan()
        {
            return _context.Loan;
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoan([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        // PUT: api/Loans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan([FromRoute] int id, [FromBody] Loan loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loan.Id)
            {
                return BadRequest();
            }

            _context.Entry(loan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Loans
        [HttpPost]
        public async Task<IActionResult> PostLoan([FromBody] Loan loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoan", new { id = loan.Id }, loan);
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loan = await _context.Loan.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            return Ok(loan);
        }

        [HttpPut("repay/{id}")]
        public ActionResult<Loan> RepayLoan([FromRoute]int id, [FromBody] Repay repay) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var loan = _context.Loan.Find(id);
            if (loan == null) {
                return BadRequest();
            }
            
            loan.RepaymentDate = repay.RepaymentDate;
            _context.SaveChanges();
            return Ok(loan);
        }

        private bool LoanExists(int id)
        {
            return _context.Loan.Any(e => e.Id == id);
        }
    }
}