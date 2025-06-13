﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvestmentTrackerAPI.Data;
using InvestmentTrackerAPI.Models;
using InvestmentTrackerAPI.Responses.Type;
using AutoMapper;
using InvestmentTrackerAPI.Responses.Category;

namespace InvestmentTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypesController : ControllerBase
    {
        private readonly InvestmentTrackerContext _context;
        private readonly IMapper _mapper;

        public TransactionTypesController(InvestmentTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TransactionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionTypeResponse>>> GetTypes()
        {
            return _mapper.Map<List<TransactionTypeResponse>>(await _context.Types.ToListAsync());
        }

        // GET: api/TransactionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionType>> GetTransactionType(int id)
        {
            var transactionType = await _context.Types.FindAsync(id);

            if (transactionType == null)
            {
                return NotFound();
            }

            return transactionType;
        }

        // PUT: api/TransactionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionType(int id, TransactionType transactionType)
        {
            if (id != transactionType.Id)
            {
                return BadRequest();
            }

            _context.Entry(transactionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionTypeExists(id))
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

        // POST: api/TransactionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionType>> PostTransactionType(TransactionType transactionType)
        {
            _context.Types.Add(transactionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionType", new { id = transactionType.Id }, transactionType);
        }

        // DELETE: api/TransactionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionType(int id)
        {
            var transactionType = await _context.Types.FindAsync(id);
            if (transactionType == null)
            {
                return NotFound();
            }

            _context.Types.Remove(transactionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionTypeExists(int id)
        {
            return _context.Types.Any(e => e.Id == id);
        }
    }
}
