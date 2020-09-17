using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CommentsController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<CommentDto>>> List()
        {
            return await Mediator.Send(new List.Query());
        }
    }
}