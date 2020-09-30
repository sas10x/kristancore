using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    public class CommentsController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<List<CommentDto>>> List(Guid id)
        {
            return await Mediator.Send(new List.Query{Id = id});
        }
    }
}