using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkClassLibrary.Relationships
{
    public class Place
    {
        [Key]
        public int? id_place { get; set; }
        public int? _id_project { get; set; }   
        public DateTime? date { get; set; }
        public int? _id_operator { get; set; }
        public string? comment { get; set; }
        public int? _id_expert { get; set; }
        public int? assessment { get; set; }
       
        public Project? project { get; set; }
        public Account? oper { get; set; }
        public Account? expert { get; set; }

        public List<Profile>? profiles { get; set; }
    }
}
