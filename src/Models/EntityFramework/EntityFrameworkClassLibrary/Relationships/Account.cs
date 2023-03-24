using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkClassLibrary.Relationships
{
    public class Account
    {
        [Key]
        public int? id_account { get; set; }
        public string? full_name { get; set; }
        public string? login { get; set; }
        public string? password { get; set; }
        public int? _id_post { get; set; }
        
        public Post? post { get; set; }

        public List<Place>? places_as_oper { get; set; }
        public List<Place>? places_as_expert { get; set; }
        public List<FinalData>? finalData_as_analytic { get; set; }
    }
}
