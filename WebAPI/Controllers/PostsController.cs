﻿using BLL.Exceptions;
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
    public class PostsController : ControllerBase, IDisposable
    {
        private readonly IPostService _postService;
        private bool _disposed;


        public PostsController(IPostService service)
        {
            _postService = service;
            _disposed = false;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostModel>>> GetPost()
        {
            return Ok(await _postService.GetAllAsync().ConfigureAwait(false));
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostModel>> GetPost(int id)
        {
            var post = await _postService.GetAsync(id).ConfigureAwait(false);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }



        // POST: api/Posts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PostModel>> PostPost([FromBody]NewPostModel model)
        {
            if (model == null)
                return BadRequest();

            int postId;
            try
            {
                postId = await _postService.NewPost(model).ConfigureAwait(false);
            }
            catch (AccessException ex)
            {
                return Forbid(ex.Message);
            }

            return Ok(postId);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<PostModel>> DeletePost(int id)
        {
            try
            {
                await _postService.DeletePost(id).ConfigureAwait(false);
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
                    _postService.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
