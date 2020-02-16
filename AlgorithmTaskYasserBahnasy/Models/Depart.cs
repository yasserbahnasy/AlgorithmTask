using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgorithmTaskYasserBahnasy.Models
{
    public class Depart
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string DepName { get; set; }

        [Required]
        [Display(Name = "Manager Full Name")]
        [ForeignKey("user")]
        public string ManagerId { get; set; }

        public virtual ApplicationUser user { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}