using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TopicService : ITopicService
    {
        private readonly Mapper _mapper;
        private readonly IRepository<Topic> _repository;
        private bool _disposed;

        public TopicService(IRepository<Topic> repository)
        {
            _repository = repository;
            _mapper = new Mapper(new MapperConfiguration(mc =>
            {
                mc.CreateMap<User, UserModel>();
                mc.CreateMap<UserModel, User>();
                mc.CreateMap<Post, PostModel>();
                mc.CreateMap<Comment, CommentModel>();
                mc.CreateMap<Topic, TopicModel>();
                mc.CreateMap<PostModel, Post>();
                mc.CreateMap<CommentModel, Comment>();
                mc.CreateMap<TopicModel, Topic>();
            }));
            _disposed = false;
        }

        public async Task CreateTopic(string name)
        {
            var topic = await _repository.GetAsync(topic => topic.Name == name).ConfigureAwait(false);

            if (topic != null)
                throw new DataException("The topic with the same name already exists");

            topic = new Topic() { Name = name };

            await _repository.InsertAsync(topic).ConfigureAwait(false);
            await _repository.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteTopic(int id)
        {
            await _repository.Remove(id).ConfigureAwait(false);
            await _repository.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TopicModel>> GetAllAsync()
        {
            var topics = await _repository.GetAllAsync().ConfigureAwait(false);

            return _mapper.Map<IEnumerable<TopicModel>>(topics);
        }

        public async Task<TopicModel> GetAsync(int id)
        {
            var topic = await _repository.GetAsync(id).ConfigureAwait(false);

            return _mapper.Map<TopicModel>(topic);
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
                    _repository.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
