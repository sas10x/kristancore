using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [AllowAnonymous]
    public class ValuesController : BaseController
    {
        // private readonly DataContext _context;
        // public ValuesController(DataContext context)
        // {
        //     _context = context;
        // }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var barcode = "978020137962";
            var kristan = 123;
            var length = barcode.Length;
            var isNumeric = int.TryParse("123", out _);
            if (isNumeric)
            {
                kristan = 1;
            }
            else {
                kristan = 2;
            }
            return new string[] { kristan.ToString() };
        }
        //  [HttpGet]
        //  //[Authorize(Policy = "IsActivityHost")]
        // public async Task<ActionResult<IEnumerable<Value>>> Get()
        // {
        //     var values = await _context.Values.ToListAsync();
        //     return Ok(values);
        // }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Value>> Get(int id)
        // {
        //     var value = await _context.Values.FindAsync(id);
        //     return Ok(value);
        // }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
