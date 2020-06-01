using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Models.FormsToFill
{
    public class NewCommentModel
    {
        public string Message { get; set; }
        public string DateCreated { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
