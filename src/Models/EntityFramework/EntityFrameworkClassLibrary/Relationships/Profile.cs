using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkClassLibrary.Relationships
{
    public class Profile
    {
        [Key]
        public int? id_profile { get; set; }
        public int? length { get; set; }
        public int? _id_place { get; set; }
        public string? raw_data_link { get; set; }
        
        public Place? place { get; set; }
    }
}
