using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgorithmTaskYasserBahnasy.Models
{
    public class Employee
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MinAge(18)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth")]
        public DateTime DOB { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hiring date")]
        public DateTime HiringDate { get; set; }

        [Display(Name = "Employee Image")]
        public string EmployeeImage { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }


        public virtual Depart Department { get; set; }
    }

    public class MinAge : ValidationAttribute
    {
        private int _Limit;
        public MinAge(int Limit)
        { // The constructor which we use in modal.
            this._Limit = Limit;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime bday = DateTime.Parse(value.ToString());
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age))
            {
                age--;
            }
            if (age < _Limit)
            {
                var result = new ValidationResult("Sorry you are not old enough");
                return result;
            }

            return null;

        }
    }
}