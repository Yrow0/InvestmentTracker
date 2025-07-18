﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvestmentTrackerAPI.Data;
using InvestmentTrackerAPI.Models;
using AutoMapper;
using InvestmentTrackerAPI.Requests.Transactions;
using InvestmentTrackerAPI.Responses.Transactions;
using System.Globalization;

namespace InvestmentTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly InvestmentTrackerContext _context;
        private readonly IMapper _mapper;
        public TransactionsController(InvestmentTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionResponse>>> GetTransactions()
        {
            return  _mapper.Map<List<TransactionResponse>>(await _context.Transactions
                .Include(t => t.Type)
                .Include(t => t.Category)
                .ToListAsync());
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(Guid id)
        {
            var transaction = await _context.Transactions
                .Include(t => t.Type)
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // GET: api/Transactions/5
        [HttpGet("monthly")]
        public async Task<ActionResult<List<TransactionsByMonth>>> GetTransactionsByMonth()
        {
            var transactions = _mapper.Map<List<TransactionResponse>>( await _context.Transactions
                .Include(t => t.Type)
                .Include(t => t.Category)
                .ToListAsync());

            var grouped = transactions
                .GroupBy(t => t.Date.ToString("yyyy-MM")) // Group by year and month
                .OrderBy(g => g.Key) // Optional: most recent month first
                .Select(g => new TransactionsByMonth
                {
                    Month = DateTime.ParseExact(g.Key, "yyyy-MM", null).ToString("MMMM", new CultureInfo("fr-FR")),
                    Year = DateTime.ParseExact(g.Key, "yyyy-MM", null).ToString("yyyy", new CultureInfo("fr-FR")), 
                    Transactions = g.ToList()
                })
                .ToList();

            return grouped;
        }

        [HttpGet("amountbycategory")]
        public async Task<ActionResult<Dictionary<int, int>>> GetTransactionAmountsByCategory()
        {
            var transactions = _mapper.Map<List<TransactionResponse>>(await _context.Transactions
                .Include(t => t.Type)
                .Include(t => t.Category)
                .ToListAsync());

            var amountByCategory = transactions
            .GroupBy(t => t.Category.Id)
            .ToDictionary(
                g => g.Key,
                g => (int)g.Sum(t => t.Amount)
            );

            return amountByCategory;
        }


        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(Guid id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
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

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(TransactionRequest _transaction)
        {
            Transaction transaction = _mapper.Map<Transaction>(_transaction);
            if(transaction.TypeId == 2)
            {
                transaction.Amount = -transaction.Amount;
            }
            _context.Transactions.Add(transaction);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TransactionExists(transaction.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(Guid id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionExists(Guid id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
