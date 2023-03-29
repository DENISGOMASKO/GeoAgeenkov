using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkClassLibrary.Relationships
{
    public class Post
    {
        [Key]
        public int? id_post { get; set; }
        public string? title { get; set; }
        public int? salary { get; set; }       
        
        public List<Account>? accounts { get; set; }
    }
}
