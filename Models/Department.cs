
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using GymSystem.Models;

namespace GymSystem.Models
{
    public class Department
    {
        public int Id { get; set; }

        [MinLength(2, ErrorMessage = "Name connot be less than 2 characters. ")]
        [MaxLength(20, ErrorMessage = "Name mustn't exceed 20 characters. ")]
        public string Name { get; set; }

        [MinLength(5, ErrorMessage = "Description connot be less than 5 characters. ")]
        [MaxLength(50, ErrorMessage = "Description mustn't exceed 50 characters. ")]
        public string Description { get; set; }

        [ValidateNever]
        public List<EmployeeGYM> Employees { get; set; }

    }
}

