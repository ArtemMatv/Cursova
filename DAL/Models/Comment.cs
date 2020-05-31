using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string DateCreated { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual User User { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        [JsonIgnore]
        public virtual Post Post { get; set; }
    }
}
