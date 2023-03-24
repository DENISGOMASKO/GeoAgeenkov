using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkClassLibrary.Relationships
{
    public class FinalData
    {
        [Key]
        public int? id_final_data { get; set; }
        public int? _id_project { get; set; }   
        public int? _id_analytic { get; set; }
        public string? final_data_link { get; set; }
        
        public Project? project { get; set; }
        public Account? analytic { get; set; }
    }
}
