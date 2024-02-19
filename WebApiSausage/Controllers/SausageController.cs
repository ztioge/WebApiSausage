﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSausage.Context;
using WebApiSausage.Models;

namespace WebApiSausage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SausageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SausageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sausage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sausage>>> GetSausages()
        {
            return await _context.Sausages.ToListAsync();
        }

        // GET: api/Sausage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sausage>> GetSausage(int id)
        {
            var sausage = await _context.Sausages.FindAsync(id);

            if (sausage == null)
            {
                return NotFound();
            }

            return sausage;
        }

        // PUT: api/Sausage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSausage(int id, Sausage sausage)
        {
            if (id != sausage.Id)
            {
                return BadRequest();
            }

            _context.Entry(sausage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SausageExists(id))
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

        // POST: api/Sausage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sausage>> PostSausage(Sausage sausage)
        {
            _context.Sausages.Add(sausage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSausage", new { id = sausage.Id }, sausage);
        }

        // DELETE: api/Sausage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSausage(int id)
        {
            var sausage = await _context.Sausages.FindAsync(id);
            if (sausage == null)
            {
                return NotFound();
            }

            _context.Sausages.Remove(sausage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SausageExists(int id)
        {
            return _context.Sausages.Any(e => e.Id == id);
        }
    }
}
