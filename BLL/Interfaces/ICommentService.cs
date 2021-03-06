﻿using BLL.Models;
using BLL.Models.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentService : IDisposable
    {
        Task<int> NewComment(NewCommentModel model);
        Task DeleteComment(int id);
        Task<IEnumerable<CommentModel>> GetAllAsync();
        Task<CommentModel> GetAsync(int id);
    }
}
