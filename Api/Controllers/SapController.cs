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
        // [HttpGet("prime")]
        // public async Task<ActionResult<List<Zmpq25b>>> Prime()
        // {
        //     return await Mediator.Send(new Prime.Query ());
        // }
        [HttpGet("availability")]
        public async Task<ActionResult<List<Zmpq25b>>> Analytics()
        {
            return await Mediator.Send(new Prime.Query());
        }

        [HttpPost("material")]
        public async Task<ActionResult<Unit>> MaterialMaster(AddMaterial.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("zmpq25b")]
        public async Task<ActionResult<Unit>> SoMaster(AddStockx.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("allsales")]
        public async Task<ActionResult<List<Zmpq25b>>> Sales()
        {
            return await Mediator.Send(new ListSales.Query());
        }
        [HttpPost("zva05n")]
        public async Task<ActionResult<Unit>> AddNewZva05n(AddZva05n.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("mb51")]
        public async Task<ActionResult<Unit>> AddNewmb51(AddMb51.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}
