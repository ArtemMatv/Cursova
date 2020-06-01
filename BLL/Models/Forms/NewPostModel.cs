using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Models.FormsToFill
{
    public class NewPostModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string DateCreated { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
    }
}