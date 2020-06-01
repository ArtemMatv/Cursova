using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string AvatarPath { get; set; }
        public bool IsBanned { get; set; }
        public bool IsSilenced { get; set; }
        public DateTime? BannedTo { get; set; }
        public DateTime? SilencedTo { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public string RoleName { get; set; }
        [ForeignKey("RoleName")]
        public virtual Role UserRole { get; set; }
        public string Token { get; set; }
    }

}
