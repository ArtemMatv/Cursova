using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("4tZCduV.7-nlTy6x/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase, IDisposable
    {
        private readonly ITopicService _topicService;
        private bool _disposed;
        public TopicController(ITopicService service)
        {
            _topicService = service;
            _disposed = false;
        }

        // GET: api/Topics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicModel>>> GetTopic()
        {
            var topics = await _topicService.GetAllAsync().ConfigureAwait(false);
            return Ok(topics);
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicModel>> GetTopic(int id)
        {
            var topic = await _topicService.GetAsync(id).ConfigureAwait(false);

            if (topic == null)
            {
                return NotFound();
            }

            return topic;
        }


        // POST: api/Topics
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TopicModel>> PostTopic([FromBody]string name)
        {
            if (name == "")
                return BadRequest();

            await _topicService.CreateTopic(name).ConfigureAwait(false);

            return Ok();
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<TopicModel>> DeleteTopic(int id)
        {
            try
            {
                await _topicService.DeleteTopic(id).ConfigureAwait(false);
            }
            catch (ArgumentException ex)
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
                    _topicService.Dispose();
                }
            }
            _disposed = true;
        }
    }
}