using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkClassLibrary.Relationships
{
    public class Project
    {
        [Key]
        public int? id_project { get; set; }
        public string? owner { get; set; }
        public int? cost { get; set; }      
        
        public List<Place>? places { get; set; }
        public List<FinalData>? finalData { get; set; }
    }
}
