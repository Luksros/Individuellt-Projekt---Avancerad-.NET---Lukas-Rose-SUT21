using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Individuellt_Projekt___Avancerad_.NET___Lukas_Rose_SUT21
{
    public  class TimeReport
    {
        [Key]
        public int Id { get; set; }

        public Project Project { get; set; }

        [Required]
        public int ProjectId { get; set; }

 
        public Employee Employee { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int Week { get; set; }

        [Required]
        public int WorkHours { get; set; }
    }
}
