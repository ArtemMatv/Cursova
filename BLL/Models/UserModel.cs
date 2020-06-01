using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string AvatarPath { get; set; }
        public DateTime? BannedTo { get; set; }
        public DateTime? SilencedTo { get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }
        public virtual ICollection<PostModel> Posts { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
    }
}
