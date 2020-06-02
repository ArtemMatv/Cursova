using BLL.Exceptions;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("4tZCduV.7-nlTy6x/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase, IDisposable
    {
        private readonly ICommentService _commentService;
        private bool _disposed;


        public CommentsController(ICommentService service)
        {
            _commentService = service;
            _disposed = false;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CommentModel>> CreateComment([FromBody]NewCommentModel model)
        {
            if (model == null)
                return BadRequest();

            int commentId;
            try
            {
                commentId = await _commentService.NewComment(model).ConfigureAwait(false);
            }
            catch (AccessException ex)
            {
                return Forbid(ex.Message);
            }

            return Ok(commentId);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<CommentModel>> DeleteComment(int id)
        {
            try
            {
                await _commentService.DeleteComment(id).ConfigureAwait(false);
            }
            catch (DataException ex)
            {
                NotFound(ex.Message);
            }

            return Ok();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _commentService.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
