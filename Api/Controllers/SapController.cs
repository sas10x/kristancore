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
        [HttpGet("zmpq25b/{article}")]
        public async Task<ActionResult<List<Zmpq25b>>> ListMZmpq25b(string article)
        {
            return await Mediator.Send(new DetailZmpq25b.Query{Article = article});
        }
        [HttpGet("mb51/{article}")]
        public async Task<ActionResult<List<Mb51>>> ListMb51(string article)
        {
            return await Mediator.Send(new DetailMb51.Query{Article = article});
        }
        [HttpGet("zva05n/{article}")]
        public async Task<ActionResult<List<Zva05n>>> ListZva05n(string article)
        {
            return await Mediator.Send(new DetailZva05n.Query{Article = article});
        }
        [HttpGet("report/data/{article}")]
        public async Task<ActionResult<List<Report>>> ListReport(string article)
        {
            return await Mediator.Send(new ReportData.Query{Article = article});
        }
        [HttpGet("report/{article}")]
        public async Task<ActionResult<ReportSummary>> Report(string article)
        {
            return await Mediator.Send(new ReportOverview.Query{Article = article});
        }
        [HttpGet("report/zor/{article}")]
        public async Task<ActionResult<List<Report>>> ListZor(string article)
        {
            return await Mediator.Send(new ReportZORSales.Query{Article = article});
        }
        [HttpGet("report/zqt/{article}")]
        public async Task<ActionResult<List<Report>>> ListZqt(string article)
        {
            return await Mediator.Send(new ReportZQTSales.Query{Article = article});
        } 
        [HttpGet("report/all/{article}")]
        public async Task<ActionResult<List<Zva05n>>> ListAll(string article)
        {
            return await Mediator.Send(new ReportAll.Query{Article = article});
        } 
      
        [HttpGet("report/bubble/{category}")]
        public async Task<ActionResult<List<Bubble>>> ListBubble(string category)
        {
            return await Mediator.Send(new ReportBubble.Query{Category = category});
        }
        // [HttpGet]
        // public async Task<ActionResult<List.ActivitiesEnvelope>> List(int? limit, 
        //     int? offset, bool isGoing, bool isHost, DateTime? startDate)
        // {
        //     return await Mediator.Send(new List.Query(limit, 
        //         offset, isGoing, isHost, startDate));
        // }
        
        // [HttpGet("report")]
        // public async Task<ActionResult<List.Bubble>> List(string? to, 
        //     string? from)
        // {
        //     return await Mediator.Send(new ReportPetsa.Query(to, 
        //         from));
        // }
        [HttpPost("add/brand")]
        public async Task<ActionResult<Unit>> AddBrand (AddBrand.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("add/category")]
        public async Task<ActionResult<Unit>> AddCategory (AddCategory.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("add/status")]
        public async Task<ActionResult<Unit>> AddStatus (AddStatus.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("add/manager")]
        public async Task<ActionResult<Unit>> AddManager (AddManager.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("get/brand")]
        public async Task<ActionResult<List<Brand>>> ListBrand()
        {
            return await Mediator.Send(new GetBrand.Query());
        }
        [HttpGet("get/manager")]
        public async Task<ActionResult<List<Manager>>> ListManager()
        {
            return await Mediator.Send(new GetManager.Query());
        }
        [HttpGet("get/status")]
        public async Task<ActionResult<List<Status>>> ListStatus()
        {
            return await Mediator.Send(new GetStatus.Query());
        }
        [HttpGet("get/category/")]
        public async Task<ActionResult<List<Category>>> ListCategories()
        {
            return await Mediator.Send(new GetCategory.Query());
        }
        // [HttpGet("report/all/{article}")]
        // public async Task<ActionResult<List<Zva05n>>> ListAll(string article)
        // {
        //     return await Mediator.Send(new ReportAll.Query{Article = article});
        // } 
    }
}
