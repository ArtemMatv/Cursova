using System.Collections.Generic;

namespace DAL.Models
{
    public class Topic
    {
        public Topic()
        {
            Posts = new List<Post>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
