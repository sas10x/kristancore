using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Microsoft.AspNetCore.Authorization;
using Application.Inventory;
using MediatR;

namespace Api.Controllers
{
    [AllowAnonymous]

    public class SapController : BaseController
    {
        // [HttpGet]
        // public async Task<ActionResult<List<Zmpq25b>>> List()
        // {
        //     return await Mediator.Send(new Sap.Query());
        // }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("{barcode}")]
        public async Task<ActionResult<List<Zmpq25b>>> List(string barcode)
        {
            return await Mediator.Send(new Sap.Query{Barcode = barcode});
        }
        [HttpGet("find/{search}")]
        public async Task<ActionResult<List<ItemDto>>> ListSearch(string search)
        {
            return await Mediator.Send(new Item.Query{Search = search});
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> MB51(Movement.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}
