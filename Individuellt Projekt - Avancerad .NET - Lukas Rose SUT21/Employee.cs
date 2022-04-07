using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Individuellt_Projekt___Avancerad_.NET___Lukas_Rose_SUT21
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(15)]
        public string FName { get; set; }

        [Required, MinLength(2), MaxLength(15)]
        public string LName { get; set; }

        [Required]
        public string Title { get; set; }
        public List<TimeReport> TimeReports { get; set; }
    }
}
